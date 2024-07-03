using ErrorOr;

namespace ExpenseManager.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Transaction
    {
        public static Error InvalidTransactionId => Error.Validation(
            code: "Transaction.InvalidTransactionId",
            description: "Transaction ID is invalid");
        public static Error InvalidTransactionType => Error.Validation(
            code: "Transaction.InvalidTransactionType",
            description: "Transaction type is invalid must be either 'Income' or 'Expense'");
    }
}