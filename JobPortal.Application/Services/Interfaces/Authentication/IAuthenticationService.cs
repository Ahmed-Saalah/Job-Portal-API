using JobPortal.Application.DTOs;
using JobPortal.Application.DTOs.Identity;

namespace JobPortal.Application.Services.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse> RegisterUser(RegisterDTO user);
        Task<LoginResponse> LoginUser(LoginDTO user);
        Task<LoginResponse> ReviveToken(string refreshToken);
    }
}
