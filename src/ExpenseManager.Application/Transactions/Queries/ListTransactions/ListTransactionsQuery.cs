using ErrorOr;

using ExpenseManager.Domain.TransactionAggregate;

using MediatR;

namespace ExpenseManager.Application.Transactions.Queries.ListTransactions;
public record ListTransactionsQuery(string PeriodId) : IRequest<ErrorOr<IEnumerable<Transaction>>>;