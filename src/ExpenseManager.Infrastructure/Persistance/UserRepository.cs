using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.UserAggregate;

namespace ExpenseManager.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
