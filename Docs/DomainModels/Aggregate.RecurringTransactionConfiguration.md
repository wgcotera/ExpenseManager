# Domain Aggregates

### RecurringTransactionConfiguration

```csharp
class RecurringTransactionConfiguration
{
    // TODO: Add methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "userId": { "value": "00000000-0000-0000-0000-000000000000" },
    "type": "income", // or "expense"
    "amount": 100.00,
    "description": "Monthly salary",
    "startDate": "2024-01-01T00:00:00.0000000Z",
    "endDate": null, // or "2024-12-31T23:59:59.9999999Z" for fixed duration
    "frequency": "monthly", // could also be "weekly", "biweekly", etc.
    "createdDateTime": "2024-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2024-01-01T00:00:00.0000000Z"
}
```