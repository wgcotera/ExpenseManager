using System.Transactions;

using ExpenseManager.Application.Periods.Commands.CreatePeriod;
using ExpenseManager.Contracts.Periods;
using ExpenseManager.Domain.PeriodAggregate;

using Mapster;

namespace ExpenseManager.Api.Common.Mapping;
public class PeriodMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreatePeriodRequest Request, string UserId), CreatePeriodCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Period, PeriodResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            // .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.TransactionIds, src => src.TransactionIds.Select(transactionId => transactionId.Value));
    }
}