using Ardalis.SmartEnum;

namespace ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.Enums;

public class Frequency : SmartEnum<Frequency>
{
    public Frequency(string name, int value) : base(name, value)
    {
    }

    public static readonly Frequency Daily = new(nameof(Daily), 1);
    public static readonly Frequency Weekly = new(nameof(Weekly), 2);
    public static readonly Frequency BiWeekly = new(nameof(BiWeekly), 3);
    public static readonly Frequency Monthly = new(nameof(Monthly), 4);
    public static readonly Frequency BiMonthly = new(nameof(BiMonthly), 5);
    public static readonly Frequency Quarterly = new(nameof(Quarterly), 6);
    public static readonly Frequency SemiAnnually = new(nameof(SemiAnnually), 7);
    public static readonly Frequency Annually = new(nameof(Annually), 8);

    public static Frequency FromName(string name) => FromName(name, ignoreCase: true);
}