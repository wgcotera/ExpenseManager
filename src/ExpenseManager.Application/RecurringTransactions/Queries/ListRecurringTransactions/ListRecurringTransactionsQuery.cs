using ErrorOr;

using ExpenseManager.Domain.RecurringTransactionAggregate;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactions.Queries.ListRecurringTransactions;
public record ListRecurringTransactionsQuery(string UserId) : IRequest<ErrorOr<IEnumerable<RecurringTransaction>>>;