using ExpenseManager.Application.Authentication.Commands.Register;
using ExpenseManager.Application.Authentication.Queries.Login;
using ExpenseManager.Application.Common.Authentication;
using ExpenseManager.Contracts.Authentication;

using Mapster;

namespace ExpenseManager.Api.Common.Mapping;
public class AuthenticationMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value.ToString())
            .Map(dest => dest, src => src.User)
            .Map(dest => dest.PeriodIds, src => src.User.PeriodIds.Select(period => period.Value.ToString()))
            .Map(dest => dest.RecurringTransactionIds, src => src.User.RecurringTransactionIds.Select(recurringTransactionId => recurringTransactionId.Value.ToString()));
    }
}