# Domain Aggregates

### Transaction

```csharp
class Transaction
{
    // TODO: Add methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "periodId": { "value": "00000000-0000-0000-0000-000000000000" },
    "recurrentTransactionConfigurationId": { "value": "00000000-0000-0000-0000-000000000000" }, // Optional, only present if it's a recurring transaction
    "type": "income", // or "expense"
    "amount": 100.00,
    "description": "Payment from SantaPriscila",
    "transactionDateTime": "2024-01-01T12:00:00.0000000Z",
    "createdDateTime": "2024-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2024-01-01T00:00:00.0000000Z"
}
```