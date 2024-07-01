using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate.Enums;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Infrastructure.Persistence.Configurations;
public class RecurringTrasactionConfiguration : IEntityTypeConfiguration<RecurringTransaction>
{
    public void Configure(EntityTypeBuilder<RecurringTransaction> builder)
    {
        ConfigureRecurringTransactionTable(builder);
        ConfigureTransactionRecurringTransactionIdsTable(builder);
    }

    private void ConfigureTransactionRecurringTransactionIdsTable(EntityTypeBuilder<RecurringTransaction> builder)
    {
        builder.OwnsMany(rt => rt.TransactionIds, t =>
        {
            t.ToTable("RecurringTransactionIds");
            t.WithOwner().HasForeignKey("RecurringTransactionId");
            t.HasKey("Id");
            t.Property(x => x.Value)
                .HasColumnName("TransactionId")
                .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(RecurringTransaction.TransactionIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureRecurringTransactionTable(EntityTypeBuilder<RecurringTransaction> builder)
    {
        builder.ToTable("RecurringTransactions");

        builder.HasKey(rt => rt.Id);
        builder.Property(rt => rt.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RecurringTransactionId.Create(value))
            .IsRequired();

        builder.Property(rt => rt.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value))
            .IsRequired();

        builder.Property(t => t.TransactionType)
            .HasConversion(
                type => type.Name,
                value => TransactionType.FromName(value))
            .IsRequired();

        builder.OwnsOne(rt => rt.Amount, a =>
        {
            a.Property(x => x.Value)
                .HasColumnName("Amount")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            a.Property(x => x.CurrencyCode)
                .HasColumnName("CurrencyCode")
                .IsRequired();
        });

        builder.Property(rt => rt.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(rt => rt.StartDate)
            .IsRequired();

        builder.Property(rt => rt.EndDate)
            .IsRequired(false);

        builder.Property(rt => rt.Frequency)
            .HasConversion(
                frequency => frequency.Name,
                value => Frequency.FromName(value))
            .IsRequired();
    }
}