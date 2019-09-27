# OAUTHWebAPI

OauthWebAPI using default ASP .Net Identity and OAuth implementation

## Running

run sql script inside Database folder to create sql server database

run solution inside Source folder and modify web.config to match your current environment

```bash
pip install foobar
```

## /api/Account/Register
used to register new user

default test user:
>username: admin@admin.com

>password: Administrator-123

or if you want to create new user

Request Format:
```json
{
  "Email": "sample string 1",
  "Password": "sample string 2",
  "ConfirmPassword": "sample string 3"
}
```
## /Token
used to request Authorization Bearer Token

Request Format using  x-www-form-urlencoding parameters including:

| key  | value |
| ------------- | ------------- |
| grant_type  | Should always be "password" without quotes  |
| username  | The API User account name  |
| password | The password for the account  |

and if success it will return json response:
```json
{
  "access_token": "This is value that will be included on each API call",
  "token_type": "string value",
  "expires_in": "The number of seconds until the token expires",
  "username": "The username as authenticated",
  ".issued": "The date issued",
  ".expires": "The date expires",
}
```
To authorize your API call please always use in request header 

**Authorization: Bearer {__your_access_token__}**

## GET api/Test/GetAllProduct
return list collection of Product

response format:
```json
{
  "products": [
    {
      "Id": 1,
      "Name": "sample string 2",
      "Stock": 1,
      "Sell_Price": 1,
      "Buy_Price": 1,
      "CreatedTime": "2019-09-27T10:30:18.3542722+07:00",
      "UpdatedTime": "2019-09-27T10:30:18.3542722+07:00",
      "CreatedById": "sample string 3",
      "UpdatedById": "sample string 4"
    },
    {
      "Id": 1,
      "Name": "sample string 2",
      "Stock": 1,
      "Sell_Price": 1,
      "Buy_Price": 1,
      "CreatedTime": "2019-09-27T10:30:18.3542722+07:00",
      "UpdatedTime": "2019-09-27T10:30:18.3542722+07:00",
      "CreatedById": "sample string 3",
      "UpdatedById": "sample string 4"
    }
  ],
  "status": "sample string 1",
  "message": "sample string 2"
}
```

## GET api/Test/GetProduct?id={id}

Get Product By Id

Response format:
```json
{
  "Id": 1,
  "Name": "sample string 2",
  "Stock": 1,
  "Sell_Price": 1,
  "Buy_Price": 1,
  "CreatedTime": "2019-09-27T10:32:07.2173803+07:00",
  "UpdatedTime": "2019-09-27T10:32:07.2173803+07:00",
  "CreatedById": "sample string 3",
  "UpdatedById": "sample string 4"
}
```

## POST api/Test/CreateProduct

Request Format:
```json
{
  "Id": 1,
  "Name": "sample string 2",
  "Stock": 1,
  "Sell_Price": 1,
  "Buy_Price": 1,
  "CreatedTime": "2019-09-27T10:33:05.0193889+07:00",
  "UpdatedTime": "2019-09-27T10:33:05.0193889+07:00",
  "CreatedById": "sample string 3",
  "UpdatedById": "sample string 4"
}
```

Response Format:
```json
{
  "code": 1,
  "message": "sample string 2"
}
```

## POST api/Test/UpdateProduct

Request Format:
```json
{
  "Id": 1,
  "Name": "sample string 2",
  "Stock": 1,
  "Sell_Price": 1,
  "Buy_Price": 1,
  "CreatedTime": "2019-09-27T10:34:21.0768201+07:00",
  "UpdatedTime": "2019-09-27T10:34:21.0768201+07:00",
  "CreatedById": "sample string 3",
  "UpdatedById": "sample string 4"
}
```

Response Format:

```json
{
  "code": 1,
  "message": "sample string 2"
}
```

## GET api/Test/DeleteProduct?id={id}

Response Format:
```json
{
  "code": 1,
  "message": "sample string 2"
}
```
