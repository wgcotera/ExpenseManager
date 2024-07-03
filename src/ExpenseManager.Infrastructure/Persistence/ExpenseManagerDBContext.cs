using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.TransactionAggregate;
using ExpenseManager.Domain.UserAggregate;
using ExpenseManager.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExpenseManager.Infrastructure.Persistence;
public class ExpenseManagerDBContext : DbContext
{
    private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor;
    public ExpenseManagerDBContext(
        DbContextOptions<ExpenseManagerDBContext> options,
        PublishDomainEventInterceptor publishDomainEventInterceptor)
        : base(options)
    {
        _publishDomainEventInterceptor = publishDomainEventInterceptor;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<RecurringTransaction> RecurringTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(ExpenseManagerDBContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}