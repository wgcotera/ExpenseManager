using FluentValidation;

namespace ExpenseManager.Application.Transactions.Queries.ListTransactions;
public class ListTransactionsQueryValidator : AbstractValidator<ListTransactionsQuery>
{
    public ListTransactionsQueryValidator()
    {
        RuleFor(x => x.PeriodId).NotEmpty();
    }
}