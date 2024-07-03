using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.Common.ValueObjects;

using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public class CreateRecurringTransactionCommandHandler

    : IRequestHandler<CreateRecurringTransactionCommand, ErrorOr<RecurringTransaction>>
{
    private readonly IRecurringTransactionRepository _recurringTransactionRepository;

    public CreateRecurringTransactionCommandHandler(
        IRecurringTransactionRepository recurringTransactionRepository
        )
    {
        _recurringTransactionRepository = recurringTransactionRepository;
    }



    public async Task<ErrorOr<RecurringTransaction>> Handle(CreateRecurringTransactionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        RecurringTransaction recurringTransaction = RecurringTransaction.Create(
            userId: UserId.Create(command.UserId),
            transactionType: command.TransactionType,
            amount: Amount.Create(command.Amount.Value, command.Amount.CurrencyCode),
            description: command.Description,
            startDate: command.StartDate,
            endDate: command.EndDate,
            frequency: command.Frequency
        );

        // Persist the recurring transaction configuration
        _recurringTransactionRepository.Add(recurringTransaction);

        // Return the recurring transaction configuration
        return recurringTransaction;
    }

}