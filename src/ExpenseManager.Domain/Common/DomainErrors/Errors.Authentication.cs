using ErrorOr;

namespace ExpenseManager.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Unauthorized(
            code: "Authentication.InvalidCredentials",
            description: "Invalid credentials."
        );
    }
}