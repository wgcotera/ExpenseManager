
using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.Common.ValueObjects;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;
using ExpenseManager.Domain.Common.DomainErrors;

using MediatR;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

namespace ExpenseManager.Application.Transactions.Commands.CreateTransaction;
public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ErrorOr<Transaction>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPeriodRepository _periodRepository;
    private readonly IRecurringTransactionRepository _recurringTransactionRepository;

    public CreateTransactionCommandHandler(
        ITransactionRepository transactionRepository,
        IPeriodRepository periodRepository,
        IRecurringTransactionRepository recurringTransactionRepository)
    {
        _transactionRepository = transactionRepository;
        _periodRepository = periodRepository;
        _recurringTransactionRepository = recurringTransactionRepository;
    }
    public async Task<ErrorOr<Transaction>> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var period = _periodRepository.GetPeriodById(PeriodId.Create(command.PeriodId));
        if (period is null)
        {
            return Errors.Period.NotFound;
        }

        Transaction transaction = Transaction.Create(
            periodId: PeriodId.Create(command.PeriodId),
            recurringTransactionId: command.RecurringTransactionId != null
                ? RecurringTransactionId.Create(command.RecurringTransactionId)
                : null,
            transactionType: command.TransactionType,
            amount: Amount.Create(command.Amount.Value, command.Amount.CurrencyCode),
            description: command.Description,
            transactionDateTime: command.TransactionDateTime
        );

        // Persist the transaction
        _transactionRepository.Add(transaction);

        // Update the period with the new transaction
        period.AddTransactionId((TransactionId)transaction.Id);
        _periodRepository.UpdatePeriod(period);

        if (command.RecurringTransactionId != null)
        {
            var recurringTransaction = _recurringTransactionRepository.GetRecurringTransactionById(RecurringTransactionId.Create(command.RecurringTransactionId));
            if (recurringTransaction is null)
            {
                return Errors.RecurringTransaction.NotFound;
            }

            recurringTransaction.AddTransactionId((TransactionId)transaction.Id);
            _recurringTransactionRepository.UpdateRecurringTransaction(recurringTransaction);
        }

        return transaction;
    }
}