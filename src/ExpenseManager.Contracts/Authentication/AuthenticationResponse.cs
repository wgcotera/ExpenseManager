namespace ExpenseManager.Contracts.Authentication;
public record AuthenticationResponse(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string Email,
    List<string> PeriodIds,
    List<string> RecurringTransactionIds,
    string Token);