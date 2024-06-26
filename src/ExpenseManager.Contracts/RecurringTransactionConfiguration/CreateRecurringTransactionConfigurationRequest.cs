using ExpenseManager.Contracts.Transactions;

namespace ExpenseManager.Contracts.RecurringTransactionConfiguration;
public record CreateRecurringTransactionConfigurationRequest(
    string TransactionType,
    TransactionAmount Amount,
    string Description,
    DateTime StartDate,
    DateTime? EndDate,
    string Frequency
);