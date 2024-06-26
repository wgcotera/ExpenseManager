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
    "id": "c3433083-ff8b-457f-b919-24116f34ff1a",
    "firstName": "Bobby",
    "lastName": "Tables",
    "userName": "boobles",
    "email": "bobbles@example.com",
    "token": "eyJhbGciOiJIUzI1NiIsInR5...qcqX8ot9XTL3hT8"
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
    "id": "c3433083-ff8b-457f-b919-24116f34ff1a",
    "firstName": "Bobby",
    "lastName": "Tables",
    "userName": "boobles",
    "email": "bobbles@example.com",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXV...NqxA06AmJFZZSevFKh_4f6Bew"
}
```
