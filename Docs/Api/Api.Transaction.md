- [Domain Aggregate](#domain-aggregate)
  - [Transaction](#transaction)
    - [Create Transaction](#create-transaction)
      - [Create Transaction Request](#create-transaction-request)
      - [Create Transaction Response](#create-transaction-response)
    - [List Transactions](#list-transactions)
      - [List Transactions Request](#list-transactions-request)
      - [List Transactions Response](#list-transactions-response)

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
    "recurringTransactionId": null,
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

### List Transactions

#### List Transactions Request

```js
GET /users/{userId}/periods/{periodId}/transactions
```

#### List Transactions Response

```js
200 Ok
```

```json
[
    {
        "id": "0ae746be-6281-41ba-b74c-f4ddbcdaa302",
        "periodId": "fa81fc26-1efc-466a-be93-f3404346b821",
        "recurringTransactionId": null,
        "transactionType": "Income",
        "amount": {
            "value": 100,
            "currencyCode": "USD"
        },
        "description": "Income from work",
        "transactionDateTime": "2021-04-01T00:00:00",
        "createdDateTime": "2024-06-27T02:19:41.51248Z",
        "updatedDateTime": "2024-06-27T02:19:41.51248Z"
    },
    {
        "id": "f180acc1-9564-4c3a-9e8c-0d994a4e3e04",
        "periodId": "fa81fc26-1efc-466a-be93-f3404346b821",
        "recurringTransactionId": null,
        "transactionType": "Expense",
        "amount": {
            "value": 69,
            "currencyCode": "USD"
        },
        "description": "Shoes on Amazon",
        "transactionDateTime": "2021-04-01T00:00:00",
        "createdDateTime": "2024-06-27T02:20:53.303616Z",
        "updatedDateTime": "2024-06-27T02:20:53.303616Z"
    }
]
```
