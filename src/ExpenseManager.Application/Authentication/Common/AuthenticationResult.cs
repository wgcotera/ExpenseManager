using ExpenseManager.Domain.UserAggregate;

namespace ExpenseManager.Domain.Common;

public record AuthenticationResult(
    User User,
    string Token
);
