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
using TaskManagerPlatform.Application.Contracts.Identity;
using TaskManagerPlatform.Application.Models.Authentication;

namespace TaskManagerPlatform.Identity.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            ////var user = await _userManager.FindByEmailAsync(request.Email);

            //if (user == null)
            //{
            //    throw new Exception($"User with {request.Email} not found.");
            //}

            ////var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            //if (!result.Succeeded)
            //{
            //    throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            //}

            //JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            //AuthenticationResponse response = new AuthenticationResponse
            //{
            //    Id = user.Id,
            //    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            //    Email = user.Email,
            //    UserName = user.UserName
            //};

            //return response;

            throw new NotImplementedException();
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            //var existingUser = await _userManager.FindByNameAsync(request.UserName);

            //if (existingUser != null)
            //{
            //    throw new Exception($"Username '{request.UserName}' already exists.");
            //}

            //var user = new ApplicationUser
            //{
            //    Email = request.Email,
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    UserName = request.UserName,
            //    EmailConfirmed = true
            //};

            //var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            //if (existingEmail == null)
            //{
            //    var result = await _userManager.CreateAsync(user, request.Password);

            //    if (result.Succeeded)
            //    {
            //        return new RegistrationResponse() { UserId = user.Id };
            //    }
            //    else
            //    {
            //        throw new Exception($"{result.Errors}");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Email {request.Email } already exists.");
            //}

            throw new NotImplementedException();
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

        //private async Task<JwtSecurityToken> GenerateToken(User user)
        //{
        //    //var userClaims = await _userManager.GetClaimsAsync(user);
        //    //var roles = await _userManager.GetRolesAsync(user);

        //    //var roleClaims = new List<Claim>();

        //    //for (int i = 0; i < roles.Count; i++)
        //    //{
        //    //    roleClaims.Add(new Claim("roles", roles[i]));
        //    //}

        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim("uid", user.Id)
        //    }
        //    .Union(userClaims)
        //    .Union(roleClaims);

        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: _jwtSettings.Issuer,
        //        audience: _jwtSettings.Audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddHours(24),
        //        signingCredentials: signingCredentials);
        //    return jwtSecurityToken;
        //}
    }
}