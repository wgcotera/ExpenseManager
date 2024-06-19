namespace ExpenseManager.Contracts.Periods;
public record CreatePeriodRequest(
    DateTime StartDate,
    DateTime EndDate
);