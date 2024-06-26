using ErrorOr;

using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;

using MediatR;

namespace ExpenseManager.Application.Transactions.Commands.CreateTransaction;
public record CreateTransactionCommand(
    string PeriodId,
    string? RecurringTransactionConfigurationId,
    TransactionType TransactionType,
    TransactionAmountCommand Amount,
    string Description,
    DateTime TransactionDateTime
) : IRequest<ErrorOr<Transaction>>;

public record TransactionAmountCommand(decimal Value, string CurrencyCode);