using ExpenseManager.Application.Authentication.Queries.ListPeriods;

using FluentValidation;

namespace ExpenseManager.Application.Periods.Queries.ListPeriods;

public class ListPeriodsQueryValidator : AbstractValidator<ListPeriodsQuery>
{
    public ListPeriodsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}