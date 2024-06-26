using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;

public interface IRecurringTransactionConfigurationRepository
{
    void Add(RecurringTransactionConfiguration recurringTransactionConfiguration);
}