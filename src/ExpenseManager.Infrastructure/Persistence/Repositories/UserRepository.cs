using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.UserAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{

    private readonly ExpenseManagerDBContext _dbContext;

    public UserRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }

    // Queries

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(UserId userId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
    }

    // Commands

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }


    public void UpdateUser(User user)
    {
        _dbContext.Update(user);
        _dbContext.SaveChanges();
    }
}
