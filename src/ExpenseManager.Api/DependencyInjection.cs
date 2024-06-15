using ExpenseManager.Api.Common.Errors;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ExpenseManager.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, ExpenseManagerProblemDetailsFactory>();
        return services;
    }
}