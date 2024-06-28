
using ErrorOr;

using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;

public interface IRecurringTransactionRepository
{
    void Add(RecurringTransaction recurringTransaction);
    List<RecurringTransaction> GetByUserId(UserId userId);

}