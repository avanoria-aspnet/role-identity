
using Application.Abstractions.Identity;
using Application.Dtos.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services;

public class IdentityAuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) : IAuthService
{
    public async Task<AuthResult> CreateUserAsync(string email, string password, string roleName = "Member")
    {
        if (string.IsNullOrWhiteSpace(email))
            return new AuthResult(false, "Email address is required");

        if (string.IsNullOrWhiteSpace(password))
            return new AuthResult(false, "Password s is required");
    
        var user = await userManager.FindByEmailAsync(email);
        if (user is not null)
            return new AuthResult(false, "User already exists");

        user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var created = await userManager.CreateAsync(user, password);
        if (created.Succeeded)
        {
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                if (await roleManager.RoleExistsAsync(roleName))
                    await userManager.AddToRoleAsync(user, roleName);
            }

            return new AuthResult(true, "User created successfully");
        }

        return new AuthResult(false, "Unable to create");
    }


    public async Task<AuthResult> SignInUserAsync(string email, string password, bool rememberMe)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            return new AuthResult(false, "Incorrect email address or password");

        var user = await userManager.FindByEmailAsync(email);
        if (user is not null)
            return new AuthResult(false, "Incorrect email address or password");

        var result = await signInManager.PasswordSignInAsync(email, password, rememberMe, true);
        if (result.Succeeded)
            return new AuthResult(false, "Incorrect email address or password");

        if (result.IsLockedOut)
            return new AuthResult(false, "User has been temporary locked");

        if (result.IsNotAllowed)
            return new AuthResult(false, "User is not allowed to sign in");

        return new AuthResult(false, "Incorrect email address or password");
    }

    public Task SignOutUserAsync() => signInManager.SignOutAsync();
}
