
using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseManager.Infrastructure.Persistence.Configurations;
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        ConfigureTransactionTable(builder);
    }

    private void ConfigureTransactionTable(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => TransactionId.Create(value))
            .IsRequired();

        builder.Property(t => t.PeriodId)
            .HasConversion(
                id => id.Value,
                value => PeriodId.Create(value))
            .IsRequired();

        builder.Property(t => t.RecurringTransactionId)
            .HasConversion(
                id => id!.Value,
                value => RecurringTransactionId.Create(value))
            .IsRequired(false);

        builder.Property(t => t.TransactionType)
            .HasConversion(
                type => type.Name,
                value => TransactionType.FromName(value))
            .IsRequired();

        builder.OwnsOne(t => t.Amount, a =>
        {
            a.Property(x => x.Value)
                .HasColumnName("Amount")
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            a.Property(x => x.CurrencyCode)
                .HasColumnName("CurrencyCode")
                .IsRequired();
        });

        builder.Property(t => t.Description)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.TransactionDateTime)
            .IsRequired();
    }
}