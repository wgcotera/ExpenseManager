- [Domain Aggregates](#domain-aggregates)
  - [Recurring Transaction Configuration](#recurring-transaction-configuration)
    - [Create Recurring Transaction Configuration](#create-recurring-transaction-configuration)
      - [Create Recurring Transaction Configuration Request](#create-recurring-transaction-configuration-request)
      - [Create Recurring Transaction Configuration Response](#create-recurring-transaction-configuration-response)
    - [List Recurring Transaction Configurations](#list-recurring-transaction-configurations)
      - [List Transaction Conguration Request](#list-transaction-conguration-request)
      - [List Transaction Configuration Response](#list-transaction-configuration-response)

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

### List Recurring Transaction Configurations

#### List Transaction Conguration Request

```js
GET /users/{userId}/recurring-transaction-configurations
```

#### List Transaction Configuration Response

```json
[
    {
        "id": "b77bc14e-3bad-4a48-9b31-de7011ee7dbb",
        "userId": "9d8cef78-e38d-4b37-a06e-cb7ae1c5f287",
        "transactionType": "Income",
        "amount": {
            "value": 400,
            "currencyCode": "USD"
        },
        "description": "Programming Services",
        "startDate": "2024-06-26T15:27:18.3014202Z",
        "endDate": null,
        "frequency": "Monthly",
        "transactionIds": [],
        "createdDateTime": "2024-06-27T16:54:48.4348172Z",
        "updatedDateTime": "2024-06-27T16:54:48.4348172Z"
    }
]
```
