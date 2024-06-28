using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

namespace ExpenseManager.Domain.TransactionAggregate;
public class Transaction : AggregateRoot<TransactionId>
{
    public PeriodId PeriodId { get; private set; }
    public RecurringTransactionId? RecurringTransactionId { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public Amount Amount { get; private set; }
    public string Description { get; private set; }
    public DateTime TransactionDateTime { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Transaction(
        TransactionId transactionId,
        PeriodId periodId,
        RecurringTransactionId? recurringTransactionId,
        TransactionType transactionType,
        Amount amount,
        string description,
        DateTime transactionDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(transactionId)
    {
        PeriodId = periodId;
        RecurringTransactionId = recurringTransactionId;
        TransactionType = transactionType;
        Amount = amount;
        Description = description;
        TransactionDateTime = transactionDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Transaction Create(
        PeriodId periodId,
        RecurringTransactionId? recurringTransactionId,
        TransactionType transactionType,
        Amount amount,
        string description,
        DateTime transactionDateTime)
    {
        return new Transaction(
            TransactionId.CreateUnique(),
            periodId,
            recurringTransactionId,
            transactionType,
            amount,
            description,
            transactionDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Transaction()
    {
    }
#pragma warning restore CS8618
}