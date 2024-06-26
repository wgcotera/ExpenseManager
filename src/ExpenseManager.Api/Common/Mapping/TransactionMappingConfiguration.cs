using ExpenseManager.Application.Transactions.Commands.CreateTransaction;
using ExpenseManager.Contracts.Transactions;
using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

using Mapster;

namespace ExpenseManager.Api.Common.Mapping
{
    public class TransactionMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateTransactionRequest Request, string PeriodId), CreateTransactionCommand>()
                .Map(dest => dest.PeriodId, src => src.PeriodId)
                .Map(dest => dest.TransactionType, src => TransactionType.FromName(src.Request.TransactionType))
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Transaction, TransactionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value.ToString())
                .Map(dest => dest.PeriodId, src => src.PeriodId.Value.ToString())
                .Map(dest => dest.TransactionType, src => src.TransactionType.Name);
        }
    }
}
