using FluentValidation;

namespace ExpenseManager.Application.Transactions.Commands.CreateTransaction;
public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.PeriodId).NotEmpty();
        RuleFor(x => x.TransactionType).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.TransactionDateTime).NotEmpty();
    }
}