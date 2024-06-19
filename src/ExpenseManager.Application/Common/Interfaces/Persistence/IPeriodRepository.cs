using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;
public interface IPeriodRepository
{
    void Add(Period period);

    List<Period> GetByUserId(UserId userId);
}