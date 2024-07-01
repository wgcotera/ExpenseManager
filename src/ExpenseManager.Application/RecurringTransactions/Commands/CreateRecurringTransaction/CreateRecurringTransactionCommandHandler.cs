using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.Common.ValueObjects;

using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;
using ExpenseManager.Domain.Common.DomainErrors;

using MediatR;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;

namespace ExpenseManager.Application.RecurringTransactions.Commands.CreateRecurringTransaction;

public class CreateRecurringTransactionCommandHandler

    : IRequestHandler<CreateRecurringTransactionCommand, ErrorOr<RecurringTransaction>>
{
    private readonly IRecurringTransactionRepository _recurringTransactionRepository;
    private readonly IUserRepository _userRepository;

    public CreateRecurringTransactionCommandHandler(
        IRecurringTransactionRepository recurringTransactionRepository,
        IUserRepository userRepository)
    {
        _recurringTransactionRepository = recurringTransactionRepository;
        _userRepository = userRepository;
    }



    public async Task<ErrorOr<RecurringTransaction>> Handle(CreateRecurringTransactionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = _userRepository.GetUserById(UserId.Create(command.UserId));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

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

        // Update the user with the new recurring transaction configuration
        user.AddRecurringTransactionId((RecurringTransactionId)recurringTransaction.Id);
        _userRepository.UpdateUser(user);

        // Return the recurring transaction configuration
        return recurringTransaction;
    }

}