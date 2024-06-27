using ExpenseManager.Application.Transactions.Commands.CreateTransaction;
using ExpenseManager.Application.Transactions.Queries.ListTransactions;
using ExpenseManager.Contracts.Transactions;
using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.TransactionAggregate;

using Mapster;

namespace ExpenseManager.Api.Common.Mapping;
public class TransactionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateTransactionRequest Request, string PeriodId), CreateTransactionCommand>()
            .Map(dest => dest.PeriodId, src => src.PeriodId)
            .Map(dest => dest.TransactionType, src => TransactionType.FromName(src.Request.TransactionType))
            .Map(dest => dest, src => src.Request);

        config.NewConfig<string, ListTransactionsQuery>()
            .MapWith(src => new ListTransactionsQuery(src));

        config.NewConfig<Transaction, TransactionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.PeriodId, src => src.PeriodId.Value.ToString())
            .Map(dest => dest.TransactionType, src => src.TransactionType.Name);

        config.NewConfig<IEnumerable<Transaction>, IEnumerable<TransactionResponse>>()
            .Map(dest => dest, src => src.Adapt<IEnumerable<TransactionResponse>>());
    }
}
