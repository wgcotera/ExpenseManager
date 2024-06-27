
using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;

using MediatR;

namespace ExpenseManager.Application.Transactions.Queries.ListTransactions;
public class ListTransactionsQueryHandler : IRequestHandler<ListTransactionsQuery, ErrorOr<IEnumerable<Transaction>>>
{
    private readonly ITransactionRepository _transactionRepository;

    public ListTransactionsQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<ErrorOr<IEnumerable<Transaction>>> Handle(ListTransactionsQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        PeriodId periodId = PeriodId.Create(query.PeriodId);
        var transactions = _transactionRepository.GetByPeriodId(periodId);

        return transactions;
    }
}