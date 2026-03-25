using Application.Abstractions.Authentication;
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
        services.AddIdentity<AppUser, IdentityRole>(x =>
        {
            x.SignIn.RequireConfirmedAccount = configuration.GetValue<bool>("IdentitySettings:ConfirmAccount");
            x.User.RequireUniqueEmail = configuration.GetValue<bool>("IdentitySettings:UseUniqueEmail");
            x.Password.RequiredLength = configuration.GetValue<int>("IdentitySettings:MinPasswordLength");
        })
        .AddEntityFrameworkStores<PersistenceContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(x =>
        {
            x.LoginPath = configuration.GetValue<string>("AppCookieSettings:LoginPath");
            x.LogoutPath = configuration.GetValue<string>("AppCookieSettings:LogoutPath");
            x.AccessDeniedPath = configuration.GetValue<string>("AppCookieSettings:AccessDeniedPath");

            x.Cookie.Name = configuration.GetValue<string>("AppCookieSettings:CookieName");
            x.ExpireTimeSpan = TimeSpan.FromDays(configuration.GetValue<int>("AppCookieSettings:ExpiresInDays"));
            x.SlidingExpiration = true;
        });

        services.AddScoped<IAuthService, IdentityAuthService>();

        return services;
    }
}
