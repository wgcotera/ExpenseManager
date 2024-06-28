using ExpenseManager.Contracts.Transactions;

namespace ExpenseManager.Contracts.RecurringTransaction;
public record CreateRecurringTransactionRequest(
    string TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    string Frequency
);