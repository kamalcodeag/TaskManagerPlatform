using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Application.Models.Authentication;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Identity.Services
{
    public class AuthenticationService: TaskManagerPlatform.Application.Contracts.Identity.IAuthenticationService
    {
        private readonly IAsyncRepository<UserToRole> _userToRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(IAsyncRepository<UserToRole> userToRoleRepository, IUserRepository userRepository, IRoleRepository roleRepository,
            IHttpContextAccessor accessor, IOptions<JwtSettings> jwtSettings)
        {
            _userToRoleRepository = userToRoleRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _accessor = accessor;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            User user = null;

            if(!string.IsNullOrWhiteSpace(request.Email))
            {
                user = await _userRepository.GetUserByEmailAsync(request.Email);
            }

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                user = await _userRepository.GetUserByUsernameAsync(request.Username);
            }

            if (user == null)
            {
                throw new Exception($"User with {request.Email} or {request.Username} not found.");
            }

            string passwordHash = "";
            bool authenticateResult = false;

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                passwordHash = CreatePasswordHash(request.Password, user.Salt);
                authenticateResult = VerifyPasswordHash(request.Password, user.Salt, passwordHash);
            }

            if (!authenticateResult)
            {
                throw new Exception($"Credentials for '{request.Email} or {request.Username} aren't valid'.");
            }

            List<Role> rolesOfUser = await _roleRepository.GetRolesOfUserAsync(user.Id);
            await SignInAsync(user, rolesOfUser);

            JwtSecurityToken jwtSecurityToken = GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            };

            return response;
        }

        public async Task<SignUpResponse> SignUpAsync(SignUpRequest request)
        {
            User user = null;

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                user = await _userRepository.GetUserByEmailAsync(request.Email);
            }

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                user = await _userRepository.GetUserByUsernameAsync(request.Username);
            }

            if (user != null)
            {
                throw new Exception($"User with {request.Email} or {request.Username} already exists.");
            }

            User organization = new User
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Email = request.Email,
                Username = request.Username,
                Salt = Guid.NewGuid().ToString().Replace("-", "") + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "")
            };

            organization.PasswordHash = CreatePasswordHash(request.Password, organization.Salt);
            await _userRepository.AddAsync(organization);

            Role adminRole = await _roleRepository.GetRoleByNameAsync("admin");

            UserToRole newUserToRole = new UserToRole
            {
                UserId = organization.Id,
                RoleId = adminRole.Id
            };

            await _userToRoleRepository.AddAsync(newUserToRole);

            return new SignUpResponse() { UserId = organization.Id };
        }

        public async Task<CreateUserResponse> CreateUserAsync(User organizationUser, CreateUserRequest request)
        {
            User user = null;

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                user = await _userRepository.GetUserByEmailAsync(request.Email);
            }

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                user = await _userRepository.GetUserByUsernameAsync(request.Username);
            }

            if (user != null)
            {
                throw new Exception($"User with {request.Email} or {request.Username} already exists.");
            }

            User newUser = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Username = request.Username,
                Salt = Guid.NewGuid().ToString().Replace("-", "") + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "")
            };

            newUser.PasswordHash = CreatePasswordHash(request.Password, newUser.Salt);
            newUser.OrganizationId = organizationUser.Id;
            await _userRepository.AddAsync(newUser);

            Role userRole = await _roleRepository.GetRoleByNameAsync("user");

            UserToRole newUserToRole = new UserToRole
            {
                UserId = newUser.Id,
                RoleId = userRole.Id
            };

            await _userToRoleRepository.AddAsync(newUserToRole);

            return new CreateUserResponse() { UserId = newUser.Id };
        }

        private string CreatePasswordHash(string password, string secretKey)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (secretKey == null) throw new ArgumentNullException(nameof(secretKey));

            StringBuilder hash = new StringBuilder();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            using (var hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(passwordBytes);
                foreach (var value in hashValue)
                {
                    hash.Append(value.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        private bool VerifyPasswordHash(string password, string secretKey, string passwordHash)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (secretKey == null) throw new ArgumentNullException(nameof(secretKey));
            if (passwordHash == null) throw new ArgumentNullException(nameof(passwordHash));

            string hash = CreatePasswordHash(password, secretKey);

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private async System.Threading.Tasks.Task SignInAsync(User user, List<Role> roles)
        {
            await _accessor.HttpContext.SignInAsync("TaskManagerPlatform",
                GetClaimsPrincipal(user, roles),
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddHours(24),
                    IsPersistent = true,
                    AllowRefresh = false
                });
        }

        private ClaimsPrincipal GetClaimsPrincipal(User user, List<Role> roles)
        {
            List<Claim> roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim("Name", user.Name),
                new Claim("Email", user.Email),
                new Claim("Username", user.Username)
            }
            .Union(roleClaims);

            ClaimsIdentity identity = new ClaimsIdentity(claims, "TaskManagerPlatform");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            return principal;
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            IEnumerable<Claim> userClaims = _accessor?.HttpContext?.User.Claims;
            IEnumerable<Claim> roleClaims = userClaims.Where(uc => uc.Type == "Role");

            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("UserId", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}