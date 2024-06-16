using ExpenseManager.Domain.UserAggregate;

namespace ExpenseManager.Domain.Common.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
