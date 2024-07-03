using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionAggregate.Enums;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Domain.RecurringTransactionAggregate;
public class RecurringTransaction : AggregateRoot<RecurringTransactionId, Guid>
{
    private readonly List<TransactionId> _transactionIds = new();
    public UserId UserId { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public Amount Amount { get; private set; }
    public string Description { get; private set; }

    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public Frequency Frequency { get; private set; }

    public IReadOnlyList<TransactionId> TransactionIds => _transactionIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private RecurringTransaction(
        RecurringTransactionId recurringTransactionId,
        UserId userId,
        TransactionType transactionType,
        Amount amount,
        string description,
        DateTime startDate,
        DateTime? endDate,
        Frequency frequency,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(recurringTransactionId)
    {
        UserId = userId;
        TransactionType = transactionType;
        Amount = amount;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Frequency = frequency;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static RecurringTransaction Create(
        UserId userId,
        TransactionType transactionType,
        Amount amount,
        string description,
        DateTime startDate,
        DateTime? endDate,
        Frequency frequency)
    {
        return new RecurringTransaction(
            RecurringTransactionId.CreateUnique(),
            userId,
            transactionType,
            amount,
            description,
            startDate,
            endDate,
            frequency,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private RecurringTransaction()
    {
    }
#pragma warning restore CS8618
}