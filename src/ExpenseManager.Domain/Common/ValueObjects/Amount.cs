using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.Common.ValueObjects;

public sealed class Amount : ValueObject
{
    public decimal Value { get; private set; }
    public string CurrencyCode { get; private set; }

    private Amount(decimal value, string currency)
    {
        Value = value;
        CurrencyCode = currency;
    }

    public static Amount Create(decimal value, string currency)
    {
        return new Amount(value, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return CurrencyCode;
    }

#pragma warning disable CS8618
    private Amount()
    {
    }
#pragma warning restore CS8618
}