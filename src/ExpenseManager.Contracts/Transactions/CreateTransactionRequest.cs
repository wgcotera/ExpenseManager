namespace ExpenseManager.Contracts.Transactions;
public record CreateTransactionRequest(
    string? RecurringTransactionId,
    string TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime TransactionDateTime
);