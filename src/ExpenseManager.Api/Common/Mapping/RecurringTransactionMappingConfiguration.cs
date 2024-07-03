using ExpenseManager.Application.RecurringTransactions.Commands.CreateRecurringTransaction;
using ExpenseManager.Application.RecurringTransactions.Queries.ListRecurringTransactions;
using ExpenseManager.Contracts.RecurringTransaction;
using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate.Enums;

using Mapster;

namespace ExpenseManager.Api.Common.Mapping;

public class RecurringTransactionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRecurringTransactionRequest Request, string UserId),
                CreateRecurringTransactionCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.TransactionType, src => TransactionType.FromName(src.Request.TransactionType))
            .Map(dest => dest.Frequency, src => Frequency.FromName(src.Request.Frequency))
            .Map(dest => dest, src => src.Request);

        config.NewConfig<string, ListRecurringTransactionsQuery>()
            .MapWith(src => new ListRecurringTransactionsQuery(src));

        config.NewConfig<RecurringTransaction, RecurringTransactionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.TransactionType, src => src.TransactionType.Name)
            .Map(dest => dest.Frequency, src => src.Frequency.Name)
            .Map(dest => dest.TransactionIds, src => src.TransactionIds.Select(transactionId => transactionId.Value));
    }
}