using FluentValidation;

namespace ExpenseManager.Application.RecurringTransactionConfigurations.Queries.ListRecurringTransactionConfigurations;
public class ListRecurringTransactionConfigurationsQueryValidator : AbstractValidator<ListRecurringTransactionConfigurationsQuery>
{
    public ListRecurringTransactionConfigurationsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}