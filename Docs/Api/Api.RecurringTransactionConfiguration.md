- [Domain Aggregates](#domain-aggregates)
  - [Recurring Transaction Configuration](#recurring-transaction-configuration)
    - [Create Recurring Transaction Configuration](#create-recurring-transaction-configuration)
      - [Create Recurring Transaction Configuration Request](#create-recurring-transaction-configuration-request)
      - [Create Recurring Transaction Configuration Response](#create-recurring-transaction-configuration-response)

# Domain Aggregates

## Recurring Transaction Configuration

### Create Recurring Transaction Configuration

#### Create Recurring Transaction Configuration Request

```js
POST /users/{userId}/recurring-transaction-configurations
```

```json
{
    "transactionType": "income",
    "amount": {
        "value": "400",
        "currencyCode": "USD"
    },
    "description": "Programming Services",
    "startDate": "2024-06-26T15:27:18.3014202Z",
    "endDate": null,
    "frequency": "monthly"
}
```

#### Create Recurring Transaction Configuration Response

```js
201 OK
```

```json
{
    "id": "ad52c5ca-ea50-4f17-87fb-8d59cb4841f6",
    "userId": "69f4b784-044a-4cf2-917d-15138962e2fb",
    "transactionType": "Income",
    "amount": {
        "value": 400,
        "currencyCode": "USD"
    },
    "description": "Programming Services",
    "startDate": "2024-06-26T15:27:18.3014202Z",
    "endDate": null,
    "frequency": "Monthly",
    "createdDateTime": "2024-06-26T18:35:26.9243912Z",
    "updatedDateTime": "2024-06-26T18:35:26.9243918Z"
}
```
