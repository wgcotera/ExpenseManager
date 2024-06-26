
using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;

using MediatR;

namespace ExpenseManager.Application.Transactions.Commands.CreateTransaction;
public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ErrorOr<Transaction>>
{
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<ErrorOr<Transaction>> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var transaction = Transaction.Create(
            periodId: PeriodId.Create(command.PeriodId),
            recurringTransactionConfigurationId: command.RecurringTransactionConfigurationId != null
                ? RecurringTransactionConfigurationId.Create(command.RecurringTransactionConfigurationId)
                : null,
            transactionType: command.TransactionType,
            amount: Amount.Create(command.Amount.Value, command.Amount.CurrencyCode),
            description: command.Description,
            transactionDateTime: command.TransactionDateTime
        );

        _transactionRepository.Add(transaction);

        return transaction;
    }
}