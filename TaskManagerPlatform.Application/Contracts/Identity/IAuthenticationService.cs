using System.Threading.Tasks;
using TaskManagerPlatform.Application.Models.Authentication;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<SignUpResponse> SignUpAsync(SignUpRequest request);
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    }
}