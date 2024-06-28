using FluentValidation;

namespace ExpenseManager.Application.RecurringTransactions.Queries.ListRecurringTransactions;
public class ListRecurringTransactionsQueryValidator : AbstractValidator<ListRecurringTransactionsQuery>
{
    public ListRecurringTransactionsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}