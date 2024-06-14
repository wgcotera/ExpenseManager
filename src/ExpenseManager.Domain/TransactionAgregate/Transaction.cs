using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

namespace ExpenseManager.Domain.TransactionAggregate;
public class Transaction : AggregateRoot<TransactionId>
{
    public PeriodId PeriodId { get; }
    public RecurringTransactionConfigurationId? RecurringTransactionConfigurationId { get; }
    public TransactionType TransactionType { get; }
    public Amount Amount { get; }
    public string Description { get; }
    public DateTime TransactionDateTime { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Transaction(
        TransactionId transactionId,
        PeriodId periodId,
        RecurringTransactionConfigurationId? recurringTransactionConfigurationId,
        TransactionType transactionType,
        Amount amount,
        string description,
        DateTime transactionDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(transactionId)
    {
        PeriodId = periodId;
        RecurringTransactionConfigurationId = recurringTransactionConfigurationId;
        TransactionType = transactionType;
        Amount = amount;
        Description = description;
        TransactionDateTime = transactionDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Transaction Create(
        PeriodId periodId,
        RecurringTransactionConfigurationId? recurringTransactionConfigurationId,
        TransactionType transactionType,
        Amount amount,
        string description,
        DateTime transactionDateTime)
    {
        return new Transaction(
            TransactionId.CreateUnique(),
            periodId,
            recurringTransactionConfigurationId,
            transactionType,
            amount,
            description,
            transactionDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}