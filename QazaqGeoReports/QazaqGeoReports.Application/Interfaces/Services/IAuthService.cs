using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.DTOs.UserDtos.AuthDtos;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface IAuthService
{
    Task<IdentityResult> RegistrationAsync(RegisterDto register);
    Task<SignInResult> LoginAsync(LoginDto login);
    Task LogoutAsync(User user);
}
