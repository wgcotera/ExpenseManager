using Ardalis.SmartEnum;

namespace ExpenseManager.Domain.Common.Enum;

public class TransactionType : SmartEnum<TransactionType>
{
    public TransactionType(string name, int value) : base(name, value)
    {
    }

    public static readonly TransactionType Expense = new(nameof(Expense), 1);
    public static readonly TransactionType Income = new(nameof(Income), 2);

    public static TransactionType FromName(string name) => FromName(name, ignoreCase: true);
}