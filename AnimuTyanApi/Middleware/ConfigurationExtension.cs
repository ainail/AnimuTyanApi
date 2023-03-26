using DataAccess.DbContext;
using DataAccess.Repository;
using Logic.Services.Tyan;
using System.Text.Json;
using Logic.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AnimuTyanApi.Middleware;

public static class ConfigurationExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });


        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddTransient<UserService>();
        services.AddTransient<UserRepository>();
        services.AddTransient<TyanService>();
        services.AddTransient<TyanRepository>();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Events.OnRedirectToLogin = (context) =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

        services.AddDbContext<AnimeTyanContext>();
    }
}