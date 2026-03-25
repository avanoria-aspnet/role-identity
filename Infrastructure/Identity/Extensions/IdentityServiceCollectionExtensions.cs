using Application.Abstractions.Identity;
using Infrastructure.Identity.Services;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Identity.Extensions;

public static class IdentityServiceCollectionExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<PersistenceContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = configuration.GetValue<string>("AppCookieSettings:LoginPath");
            options.Cookie.Name = configuration.GetValue<string>("AppCookieSettings: CookieName");
            options.ExpireTimeSpan = TimeSpan.FromDays(configuration.GetValue<int>("AppCookieSettings: CookieExpireInDates"));
            options.SlidingExpiration = true;
        });

        services.AddScoped<IAuthService, IdentityAuthService>();
        
        return services;
    }
}
