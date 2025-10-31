using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Videohosting.Host.Options;

namespace Videohosting.Host.Extensions;

/// <summary>
/// Методы расширения для <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует <see cref="IOptions{TOptions}"/>
    /// </summary>
    /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns>Модифицированный <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddOptions(this IServiceCollection serviceCollection, IConfiguration configuration) =>
        serviceCollection.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

    /// <summary>
    /// Добавляет аутентификацию для API.
    /// </summary>
    /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns>Модифицированный <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddApiAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("JwtOptions")
            .Get<JwtOptions>()!;

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateIssuer = jwtOptions.ValidateIssuer,
                    ValidAudience = jwtOptions.Audience,
                    ValidateAudience = jwtOptions.ValidateAudience,
                    ValidateLifetime = jwtOptions.ValidateLifetime,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                    ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
                    ClockSkew = TimeSpan.FromMinutes(jwtOptions.ClockSkewMinute)
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = (context) =>
                    {
                        context.Token = context.Request.Cookies["BEST-TOKEN"];

                        return Task.CompletedTask;
                    }
                };
            });

        serviceCollection.AddAuthorization();

        return serviceCollection;
    }
}