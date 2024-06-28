using FluentValidation;

namespace ExpenseManager.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public class CreateRecurringTransactionCommandValidator
    : AbstractValidator<CreateRecurringTransactionCommand>
{
    public CreateRecurringTransactionCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.TransactionType).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.Frequency).NotEmpty();
    }
}