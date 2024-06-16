# Expense Manager API

- [Expense Manager API](#expense-manager-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register

#### Register Request

```js
POST /auth/register
```

```json
{
    "firstName": "Bobby",
    "lastName": "Tables",
    "userName": "bobbles",
    "email": "bobbles@example.com",
    "password": "Amiko69!" // TODO: Hash this
}
```

#### Register Response

```js
200 OK
```

```json
{
  "user": {
    "firstName": "Bobby",
    "lastName": "Tables",
    "username": "boobles",
    "email": "bobbles@example.com",
    "password": "Amiko69!",
    "createdDateTime": "2024-06-16T05:45:24.783486Z",
    "updatedDateTime": "2024-06-16T05:45:24.783486Z",
    "periodIds": [],
    "recurringTransactionConfigurationIds": [],
    "id": {
      "value": "00000000-0000-0000-0000-000000000000"
    }
  },
  "token": "eyJhbGci...Cyk3lVK-95NHixZZa8FDE"
}
```

### Login

#### Login Request

```js
POST /auth/login
```

```json
{
    "email": "bobbles@example.com",
    "password": "Amiko69!"
}
```

```js
200 OK
```

#### Login Response

```json
{
    "id": "d89c2d9a-eb3e-4075-95ff-b920b55aa104",
    "firstName": "Bobby",
    "lastName": "Tables",
    "userName": "bobbles",
    "email": "bobbles@example.com",
    "token": "eyJhb..z9dqcnXoY"
}
```