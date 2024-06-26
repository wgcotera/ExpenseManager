namespace ExpenseManager.Contracts.Transactions;
public record CreateTransactionRequest(
    string? RecurringTransactionConfigurationId,
    string TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime TransactionDateTime
);