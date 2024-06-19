using ExpenseManager.Domain.PeriodAggregate;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;
public interface IPeriodRepository
{
    void Add(Period period);

    List<Period> GetAll();
}