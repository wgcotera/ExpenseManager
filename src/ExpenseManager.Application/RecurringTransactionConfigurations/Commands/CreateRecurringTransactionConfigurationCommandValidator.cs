using FluentValidation;

namespace ExpenseManager.Application.RecurringTransactionConfigurations.Commands;

public class CreateRecurringTransactionConfigurationCommandValidator 
    : AbstractValidator<CreateRecurringTransactionConfigurationCommand>
{
    public CreateRecurringTransactionConfigurationCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.TransactionType).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.Frequency).NotEmpty();
    }
}