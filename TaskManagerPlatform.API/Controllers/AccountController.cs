using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Identity;
using TaskManagerPlatform.Application.Models.Authentication;

namespace TaskManagerPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("signup")]
        public async Task<ActionResult<SignUpResponse>> SignUpAsync(SignUpRequest request)
        {
            return Ok(await _authenticationService.SignUpAsync(request));
        }

        //[AuthorizeRoles(Role.Admin)]
        [HttpPost("createuser")]
        public async Task<ActionResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
        {
            return Ok(await _authenticationService.CreateUserAsync(request));
        }
    }

    //public class AuthorizeRolesAttribute : AuthorizeAttribute
    //{
    //    public AuthorizeRolesAttribute(params string[] roles) : base()
    //    {
    //        Roles = string.Join(",", roles);
    //    }
    //}

    //public static class Role
    //{
    //    public const string Admin = "admin";
    //    public const string User = "user";
    //}
}