
namespace ExpenseManager.Contracts.Periods;
public record PeriodResponse(
    string Id,
    string UserId,
    DateTime StartDate,
    DateTime EndDate,
    List<string> TransactionIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);