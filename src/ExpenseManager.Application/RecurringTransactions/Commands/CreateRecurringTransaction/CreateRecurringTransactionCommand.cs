using ErrorOr;

using ExpenseManager.Application.Common;

using ExpenseManager.Domain.Common.Enum;

using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate.Enums;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public record CreateRecurringTransactionCommand(
    string UserId,
    TransactionType TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    Frequency Frequency) : IRequest<ErrorOr<RecurringTransaction>>;