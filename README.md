# Customer API

A simple ASP.NET Core Web API for managing customers using Entity Framework Core and SQL Server.

## Features

- Get all customers
- Get customer by ID
- Add new customer
- Update existing customer
- Delete customer
- Search customers by name

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server

## Project Structure

```text
CustomerApii/
│
├── Controllers/
│   └── CustomersController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   ├── Customer.cs
│   └── CustomerRequest.cs
│
├── appsettings.json
├── Program.cs
└── README.md
```

## API Endpoints

### Get all customers

```http
GET /api/Customers
```

### Get customer by ID

```http
GET /api/Customers/{id}
```

### Create customer

```http
POST /api/Customers
```

Request body:

```json
{
  "name": "Anas",
  "phone": "0790000000"
}
```

### Update customer

```http
PUT /api/Customers/{id}
```

Request body:

```json
{
  "name": "Anas Updated",
  "phone": "0791111111"
}
```

### Delete customer

```http
DELETE /api/Customers/{id}
```

### Search customers by name

```http
GET /api/Customers/search?name=Anas
```
