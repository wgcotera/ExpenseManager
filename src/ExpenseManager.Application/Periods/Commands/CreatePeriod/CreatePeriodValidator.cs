using FluentValidation;

namespace ExpenseManager.Application.Periods.Commands.CreatePeriod;
public class CreatePeriodValidator : AbstractValidator<CreatePeriodCommand>
{
    public CreatePeriodValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
    }
}