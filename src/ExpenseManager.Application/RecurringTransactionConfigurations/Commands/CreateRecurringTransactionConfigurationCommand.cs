using ErrorOr;

using ExpenseManager.Application.Common;

using ExpenseManager.Domain.Common.Enum;

using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.Enums;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactionConfigurations.Commands;

public record CreateRecurringTransactionConfigurationCommand(
    string UserId,
    TransactionType TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    Frequency Frequency) : IRequest<ErrorOr<RecurringTransactionConfiguration>>;