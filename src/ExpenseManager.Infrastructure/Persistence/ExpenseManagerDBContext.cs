using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.TransactionAggregate;
using ExpenseManager.Domain.UserAggregate;

using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Infrastructure.Persistence;
public class ExpenseManagerDBContext : DbContext
{
    public ExpenseManagerDBContext(DbContextOptions<ExpenseManagerDBContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<RecurringTransaction> RecurringTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseManagerDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}