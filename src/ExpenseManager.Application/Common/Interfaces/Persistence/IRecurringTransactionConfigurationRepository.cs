
using ErrorOr;

using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;

public interface IRecurringTransactionConfigurationRepository
{
    void Add(RecurringTransactionConfiguration recurringTransactionConfiguration);
    List<RecurringTransactionConfiguration> GetByUserId(UserId userId);

}