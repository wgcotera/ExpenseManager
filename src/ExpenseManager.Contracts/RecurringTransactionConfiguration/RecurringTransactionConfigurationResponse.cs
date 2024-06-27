using ExpenseManager.Contracts.Transactions;

namespace ExpenseManager.Contracts.RecurringTransactionConfiguration;

public record RecurringTransactionConfigurationResponse(
    string Id,
    string UserId,
    string TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    string Frequency,
    List<string> TransactionIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);