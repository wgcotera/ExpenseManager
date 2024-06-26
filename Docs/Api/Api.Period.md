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
        "id": "00000000-0000-0000-0000-000000000000",
        "userId": "00000000-0000-0000-0000-000000000000",
        "startDate": "2024-01-01T00:00:00.0000000Z",
        "endDate": "2024-01-15T23:59:59.9999999Z",
        "transactionIds": [
            "00000000-0000-0000-0000-000000000001",
            "00000000-0000-0000-0000-000000000002",
            "00000000-0000-0000-0000-000000000003"
        ],
        "createdDateTime": "2024-01-01T00:00:00.0000000Z",
        "updatedDateTime": "2024-01-01T00:00:00.0000000Z"
    }
]
```
