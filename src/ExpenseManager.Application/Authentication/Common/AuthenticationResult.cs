using ExpenseManager.Domain.UserAggregate;

namespace ExpenseManager.Application.Common.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
