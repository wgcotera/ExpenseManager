using System.Text;

using ExpenseManager.Application.Common.Interfaces.Authentication;
using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Application.Common.Interfaces.Services;
using ExpenseManager.Infrastructure.Authentication;
using ExpenseManager.Infrastructure.Persistence;
using ExpenseManager.Infrastructure.Persistence.Interceptors;
using ExpenseManager.Infrastructure.Persistence.Repositories;
using ExpenseManager.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExpenseManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistance();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    public static IServiceCollection AddPersistance(
        this IServiceCollection services)
    {
        services.AddDbContext<ExpenseManagerDBContext>(options
            => options.UseSqlServer("Server=localhost;Database=ExpenseManager;User Id=sa;Password=amiko123!;TrustServerCertificate=True;"));

        services.AddScoped<PublishDomainEventInterceptor>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPeriodRepository, PeriodRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IRecurringTransactionRepository, RecurringTransactionRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        // services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });
        return services;
    }

}