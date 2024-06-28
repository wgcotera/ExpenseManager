using ErrorOr;

using ExpenseManager.Application.Common;
using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.TransactionAggregate;

using MediatR;

namespace ExpenseManager.Application.Transactions.Commands.CreateTransaction;
public record CreateTransactionCommand(
    string PeriodId,
    string? RecurringTransactionId,
    TransactionType TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime TransactionDateTime
) : IRequest<ErrorOr<Transaction>>;

