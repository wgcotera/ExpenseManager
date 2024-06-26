- [Domain Aggregate](#domain-aggregate)
  - [Transaction](#transaction)
    - [Create Transaction](#create-transaction)
      - [Create Transaction Request](#create-transaction-request)
      - [Create Transaction Response](#create-transaction-response)

# Domain Aggregate

## Transaction

### Create Transaction

#### Create Transaction Request

```js
POST /users/{userId}/periods/{periodId}
```

```json
{
    "transactionType": "income", // or expense
    "amount": {
        "value": 100,
        "currencyCode": "USD"
    },
    "description": "deleting db tables",
    "transactionDateTime": "2024-01-01T12:00:00.0000000Z",
}
```

#### Create Transaction Response

```js
201 OK
```

```json
{
    "id": "59ea8c1f-f32b-4ad8-8a21-f89b58316c28",
    "periodId": "74a07f0f-861e-482b-92ec-b88a0508e50e",
    "recurringTransactionConfigurationId": null,
    "transactionType": "Income",
    "amount": {
        "value": 100,
        "currencyCode": "USD"
    },
    "description": "Income from work",
    "transactionDateTime": "2021-04-01T00:00:00",
    "createdDateTime": "2024-06-26T05:01:13.644086Z",
    "updatedDateTime": "2024-06-26T05:01:13.644086Z"
}
```
