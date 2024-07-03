using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.PeriodAggregate.Events;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Domain.PeriodAggregate;
public class Period : AggregateRoot<PeriodId>
{
    private readonly List<TransactionId> _transactionIds = new();

    public UserId UserId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<TransactionId> TransactionIds => _transactionIds.AsReadOnly();

    private Period(
        UserId userId,
        DateTime startDate,
        DateTime endDate,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        PeriodId? periodId = null) : base(periodId ?? PeriodId.CreateUnique())
    {
        UserId = userId;
        StartDate = startDate;
        EndDate = endDate;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Period Create(
        UserId userId,
        DateTime startDate,
        DateTime endDate)
    {
        var period = new Period(
            userId,
            startDate,
            endDate,
            DateTime.UtcNow,
            DateTime.UtcNow);

        period.AddDomainEvent(new PeriodCreated(period));
        return period;
    }

#pragma warning disable CS8618
    private Period()
    {
    }
#pragma warning restore CS8618
}