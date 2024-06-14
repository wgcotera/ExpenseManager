using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

namespace ExpenseManager.Domain.PeriodAggregate;
public class Period : AggregateRoot<PeriodId>
{
    private readonly List<TransactionId> _transactionIds = new();

    public DateTime StartDate { get; }
    public DateTime EndDate { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<TransactionId> TransactionIds => _transactionIds.AsReadOnly();

    private Period(
        PeriodId periodId,
        DateTime startDate,
        DateTime endDate,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(periodId)
    {
        StartDate = startDate;
        EndDate = endDate;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Period Create(
        DateTime startDate,
        DateTime endDate)
    {
        return new Period(
            PeriodId.CreateUnique(),
            startDate,
            endDate,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}