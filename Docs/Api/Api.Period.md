- [Domain Aggregates](#domain-aggregates)
  - [Period](#period)
    - [Create Period](#create-period)
      - [Create Period Request](#create-period-request)
      - [Create Period Response](#create-period-response)
    - [List Periods](#list-periods)
      - [List Periods Request](#list-periods-request)
      - [List Periods Response](#list-periods-response)

# Domain Aggregates

## Period

### Create Period

#### Create Period Request

```js
POST /users/{userId}/periods
```

```json
{
    "startDate": "2024-01-01T00:00:00.0000000Z",
    "endDate": "2024-01-15T23:59:59.9999999Z",
}
```

#### Create Period Response

```js
201 OK
```

```json
{
    "id": "74a07f0f-861e-482b-92ec-b88a0508e50e",
    "userId": "c3433083-ff8b-457f-b919-24116f34ff1a",
    "startDate": "2024-01-01T00:00:00",
    "endDate": "2024-01-05T00:00:00",
    "transactionIds": [],
    "createdDateTime": "2024-06-26T05:01:10.380075Z",
    "updatedDateTime": "2024-06-26T05:01:10.380075Z"
}
```

### List Periods

#### List Periods Request

```js
GET /users/{userId}/periods
```

#### List Periods Response

```js
200 Ok
```

```json
[
    {
        "id": "41293664-a4d7-4d88-b70b-7e89dc81435a",
        "userId": "8fc1de72-437f-4ced-b8e4-2c34d94181de",
        "startDate": "2024-01-01T00:00:00",
        "endDate": "2024-01-15T00:00:00",
        "transactionIds": [
            "00000000-0000-0000-0000-000000000001",
            "00000000-0000-0000-0000-000000000002",
            "00000000-0000-0000-0000-000000000003"
        ],
        "createdDateTime": "2024-06-27T02:28:16.257638Z",
        "updatedDateTime": "2024-06-27T02:28:16.257639Z"
    },
    {
        "id": "3174ebc1-8ba6-4f10-acd5-96084771ba50",
        "userId": "8fc1de72-437f-4ced-b8e4-2c34d94181de",
        "startDate": "2024-01-16T00:00:00",
        "endDate": "2024-01-31T00:00:00",
        "transactionIds": [
            "00000000-0000-0000-0000-000000000001",
            "00000000-0000-0000-0000-000000000002",
            "00000000-0000-0000-0000-000000000003"
        ],
        "createdDateTime": "2024-06-27T02:28:34.446993Z",
        "updatedDateTime": "2024-06-27T02:28:34.446993Z"
    }
]
```
