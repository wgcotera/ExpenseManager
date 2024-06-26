using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.Common.ValueObjects;

using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactionConfigurations.Commands;

public class CreateRecurringTransactionConfigurationCommandHandler

    : IRequestHandler<CreateRecurringTransactionConfigurationCommand, ErrorOr<RecurringTransactionConfiguration>>
{
    private readonly IRecurringTransactionConfigurationRepository _recurringTransactionConfigurationRepository;

    public CreateRecurringTransactionConfigurationCommandHandler(
        IRecurringTransactionConfigurationRepository recurringTransactionConfigurationRepository)
    {
        _recurringTransactionConfigurationRepository = recurringTransactionConfigurationRepository;
    }


    public async Task<ErrorOr<RecurringTransactionConfiguration>> Handle(CreateRecurringTransactionConfigurationCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create a new recurring transaction configuration
        var recurringTransactionConfiguration = RecurringTransactionConfiguration.Create(
            userId: UserId.Create(command.UserId),
            transactionType: command.TransactionType,
            amount: Amount.Create(command.Amount.Value, command.Amount.CurrencyCode),
            description: command.Description,
            startDate: command.StartDate,
            endDate: command.EndDate,
            frequency: command.Frequency
        );

        // Persist the recurring transaction configuration
        _recurringTransactionConfigurationRepository.Add(recurringTransactionConfiguration);

        // Return the recurring transaction configuration
        return recurringTransactionConfiguration;
    }

}