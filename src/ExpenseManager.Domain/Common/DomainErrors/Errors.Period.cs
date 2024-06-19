using ErrorOr;

namespace ExpenseManager.Domain.Common.DomainErrors;
public static partial class Errors
{
    public static class Period
    {
        public static Error InvalidPeriodId => Error.Validation(
            code: "Period.InvalidId",
            description: "Period ID is invalid");

        public static Error NotFound => Error.NotFound(
            code: "Period.NotFound",
            description: "Period with given ID does not exist");

        public static Error InvalidUserId => Error.Validation(
            code: "Period.InvalidUserId",
            description: "User ID is invalid");
    }
}