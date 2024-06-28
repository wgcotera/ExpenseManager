using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.UserAggregate;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{

    private readonly ExpenseManagerDBContext _dbContext;

    public UserRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }
    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }
}
