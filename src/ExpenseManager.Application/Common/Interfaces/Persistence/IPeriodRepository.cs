using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;
public interface IPeriodRepository
{
    // Queries
    List<Period> GetByUserId(UserId userId);
    Period? GetPeriodById(PeriodId periodId);

    // Commands
    void Add(Period period);
    void UpdatePeriod(Period period);
}