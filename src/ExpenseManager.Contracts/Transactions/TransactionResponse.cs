namespace ExpenseManager.Contracts.Transactions;
public record TransactionResponse
(
    string Id,
    string PeriodId,
    string? RecurringTransactionConfigurationId,
    string TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime TransactionDateTime,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);