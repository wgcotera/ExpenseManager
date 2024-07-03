﻿// <auto-generated />
using System;
using ExpenseManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseManager.Infrastructure.Migrations
{
    [DbContext(typeof(ExpenseManagerDBContext))]
    partial class ExpenseManagerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseManager.Domain.PeriodAggregate.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Periods", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.RecurringTransactionAggregate.RecurringTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RecurringTransactions", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.TransactionAggregate.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RecurringTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.PeriodAggregate.Period", b =>
                {
                    b.OwnsMany("ExpenseManager.Domain.TransactionAggregate.ValueObjects.TransactionId", "TransactionIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("PeriodId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TransactionId");

                            b1.HasKey("Id");

                            b1.HasIndex("PeriodId");

                            b1.ToTable("PeriodTransactionIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PeriodId");
                        });

                    b.Navigation("TransactionIds");
                });

            modelBuilder.Entity("ExpenseManager.Domain.RecurringTransactionAggregate.RecurringTransaction", b =>
                {
                    b.OwnsOne("ExpenseManager.Domain.Common.ValueObjects.Amount", "Amount", b1 =>
                        {
                            b1.Property<Guid>("RecurringTransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CurrencyCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CurrencyCode");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18, 2)")
                                .HasColumnName("Amount");

                            b1.HasKey("RecurringTransactionId");

                            b1.ToTable("RecurringTransactions");

                            b1.WithOwner()
                                .HasForeignKey("RecurringTransactionId");
                        });

                    b.OwnsMany("ExpenseManager.Domain.TransactionAggregate.ValueObjects.TransactionId", "TransactionIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("RecurringTransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TransactionId");

                            b1.HasKey("Id");

                            b1.HasIndex("RecurringTransactionId");

                            b1.ToTable("RecurringTransactionIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("RecurringTransactionId");
                        });

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("TransactionIds");
                });

            modelBuilder.Entity("ExpenseManager.Domain.TransactionAggregate.Transaction", b =>
                {
                    b.OwnsOne("ExpenseManager.Domain.Common.ValueObjects.Amount", "Amount", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CurrencyCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CurrencyCode");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18, 2)")
                                .HasColumnName("Amount");

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.Navigation("Amount")
                        .IsRequired();
                });

            modelBuilder.Entity("ExpenseManager.Domain.UserAggregate.User", b =>
                {
                    b.OwnsMany("ExpenseManager.Domain.PeriodAggregate.ValueObjects.PeriodId", "PeriodIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PeriodId");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserPeriodsIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects.RecurringTransactionId", "RecurringTransactionIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("RecurringTransactionId");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserRecurringTransactionIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PeriodIds");

                    b.Navigation("RecurringTransactionIds");
                });
#pragma warning restore 612, 618
        }
    }
}
