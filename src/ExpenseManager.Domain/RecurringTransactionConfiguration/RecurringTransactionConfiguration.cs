using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionConfiguration.ValueObjects;
using ExpenseManager.Domain.User.ValueObjects;

namespace ExpenseManager.Domain.RecurringTransactionConfiguration;
public class RecurringTransactionConfiguration : AggregateRoot<RecurringTransactionConfigurationId>
{
    public UserId UserId { get; }
    public TransactionType TransactionType { get; }
    public float Amount { get; }
    public string Description { get; }

    public DateTime StartDate { get; }
    public DateTime? EndDate { get; }

    public Frequency Frequency { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private RecurringTransactionConfiguration(
        RecurringTransactionConfigurationId recurringTransactionConfigurationId,
        UserId userId,
        TransactionType transactionType,
        float amount,
        string description,
        DateTime startDate,
        DateTime? endDate,
        Frequency frequency,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(recurringTransactionConfigurationId)
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

    public static RecurringTransactionConfiguration Create(
        UserId userId,
        TransactionType transactionType,
        float amount,
        string description,
        DateTime startDate,
        DateTime? endDate,
        Frequency frequency)
    {
        return new RecurringTransactionConfiguration(
            RecurringTransactionConfigurationId.CreateUnique(),
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
}