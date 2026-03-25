using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Utils;

public class PersistenceInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<PersistenceContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        await InitializeDatabaseAsync(context);
        await SeedDefaultRolesAsync(roleManager);
        await SeedDefaultAccountsAsync(userManager);
    }

    private static async Task InitializeDatabaseAsync(PersistenceContext context)
    {
        await context.Database.MigrateAsync();
    }

    private static async Task SeedDefaultRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> { "Admin", "Member" };

        foreach(var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    private static async Task SeedDefaultAccountsAsync(UserManager<ApplicationUser> userManager)
    {
        var email = "admin@domain.com";
        var password = "BytMig123!";
        var role = "Admin";

        if (!await userManager.Users.AnyAsync())
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!await userManager.IsInRoleAsync(user, role))
                    await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
