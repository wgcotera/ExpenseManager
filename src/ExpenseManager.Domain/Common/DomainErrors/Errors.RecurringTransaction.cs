using ErrorOr;

namespace ExpenseManager.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class RecurringTransaction
    {
        public static Error InvalidRecurringTransactionId => Error.Validation(
            code: "RecurringTransaction.InvalidId",
            description: "Recurring Transaction ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "RecurringTransaction.NotFound",
            description: "Recurring Transaction with given ID does not exist");

        public static Error InvalidUserId => Error.Validation(
            code: "RecurringTransaction.InvalidUserId",
            description: "User ID is invalid");
    }
}