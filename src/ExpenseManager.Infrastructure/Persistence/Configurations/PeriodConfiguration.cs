using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Infrastructure.Persistence.Configurations;
public class PeriodConfiguration : IEntityTypeConfiguration<Period>
{
    public void Configure(EntityTypeBuilder<Period> builder)
    {
        ConfigurePeriodTable(builder);
        ConfigureUserTransactionIdsTable(builder);
    }

    private void ConfigureUserTransactionIdsTable(EntityTypeBuilder<Period> builder)
    {
        builder.OwnsMany(p => p.TransactionIds, t =>
        {
            t.ToTable("PeriodTransactionIds");
            t.WithOwner().HasForeignKey("PeriodId");
            t.HasKey("Id");
            t.Property(x => x.Value)
                .HasColumnName("TransactionId")
                .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Period.TransactionIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePeriodTable(EntityTypeBuilder<Period> builder)
    {
        builder.ToTable("Periods");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PeriodId.Create(value))
            .IsRequired();

        builder.Property(p => p.StartDate)
            .IsRequired();
        builder.Property(p => p.EndDate)
            .IsRequired();

        builder.Property(p => p.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value))
            .IsRequired();
    }
}
