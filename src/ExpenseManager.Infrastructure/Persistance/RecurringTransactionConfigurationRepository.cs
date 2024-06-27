using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;

public class RecurringTransactionConfigurationRepository : IRecurringTransactionConfigurationRepository
{
    private readonly List<RecurringTransactionConfiguration> _recurringTransactionConfigurations = new();

    public void Add(RecurringTransactionConfiguration recurringTransactionConfiguration)
    {
        _recurringTransactionConfigurations.Add(recurringTransactionConfiguration);
    }
}