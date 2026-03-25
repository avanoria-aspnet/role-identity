using Application.Dtos.Identity;

namespace Application.Abstractions.Identity;

public interface IAuthService
{
    Task<AuthResult> CreateUserAsync(string email, string password, string roleName = "Member");
    Task<AuthResult> SignInUserAsync(string email, string password, bool rememberMe);
    Task SignOutUserAsync();
}
