using System.Threading.Tasks;
using TaskManagerPlatform.Application.Models.Authentication;

namespace TaskManagerPlatform.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}