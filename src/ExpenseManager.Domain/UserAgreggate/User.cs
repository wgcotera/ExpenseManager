using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Domain.UserAggregate;
public class User : AggregateRoot<UserId, Guid>
{
    private readonly List<PeriodId> _periodIds = new();
    private readonly List<RecurringTransactionId> _recurringTransactionIds = new();

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<PeriodId> PeriodIds => _periodIds.AsReadOnly();
    public IReadOnlyList<RecurringTransactionId> RecurringTransactionIds => _recurringTransactionIds.AsReadOnly();

    private User(
        string firstName,
        string lastName,
        string username,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        UserId? userId = null) : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(
        string firstName,
        string lastName,
        string username,
        string email,
        string password)
    {
        return new User(
            firstName,
            lastName,
            username,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddPeriodId(PeriodId periodId)
    {
        _periodIds.Add(periodId);
    }

    public void AddRecurringTransactionId(RecurringTransactionId recurringTransactionId)
    {
        _recurringTransactionIds.Add(recurringTransactionId);
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}