using BuberDinner.Domain.Common.Models;

namespace ExpenseManager.Domain.Common.ValueObjects;

public sealed class Amount : ValueObject
{
    public decimal Value { get; private set; }
    public string Currency { get; private set; }

    private Amount(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Amount Create(decimal value, string currency)
    {
        return new Amount(value, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }
}