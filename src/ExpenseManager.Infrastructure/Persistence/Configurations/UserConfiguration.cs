
using ExpenseManager.Domain.UserAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
        ConfigureUserPeriodIdsTable(builder);
        ConfigureUserRecurringTransactionIdsTable(builder);
    }

    private void ConfigureUserRecurringTransactionIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(u => u.RecurringTransactionIds, r =>
        {
            r.ToTable("UserRecurringTransactionIds");
            r.WithOwner().HasForeignKey("UserId");
            r.HasKey("Id");
            r.Property(x => x.Value)
                .HasColumnName("RecurringTransactionId")
                .ValueGeneratedNever();
        });
    }

    private void ConfigureUserPeriodIdsTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(u => u.PeriodIds, p =>
        {
            p.ToTable("UserPeriodsIds");
            p.WithOwner().HasForeignKey("UserId");
            p.HasKey("Id");
            p.Property(x => x.Value)
                .HasColumnName("PeriodId")
                .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(User.PeriodIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value))
            .IsRequired();

        builder.Property(u => u.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Username)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasMaxLength(50)
            .IsRequired();

    }
}