using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence;

public class RecurringTransactionConfigurationRepository : IRecurringTransactionConfigurationRepository
{
    private readonly List<RecurringTransactionConfiguration> _recurringTransactionConfigurations = new();

    public void Add(RecurringTransactionConfiguration recurringTransactionConfiguration)
    {
        _recurringTransactionConfigurations.Add(recurringTransactionConfiguration);
    }

    public List<RecurringTransactionConfiguration> GetByUserId(UserId userId)
    {
        return _recurringTransactionConfigurations.FindAll(x => x.UserId == userId);
    }
}