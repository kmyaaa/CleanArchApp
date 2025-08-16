# Clean Architecture API

A .NET 9 Web API built with Clean Architecture principles, featuring CRUD operations and comprehensive error handling.

## Architecture

- **Domain**: Entities and repository interfaces
- **Application**: Business logic with CQRS using MediatR
- **Infrastructure**: Data access with Entity Framework Core
- **WebAPI**: REST API controllers

## Features

- Clean Architecture with dependency inversion
- Repository pattern for data access
- Mediator pattern with MediatR for CQRS
- Result pattern for error handling
- Entity Framework Core with SQL Server
- Swagger/OpenAPI documentation
- Global exception handling

## Getting Started

### Prerequisites

- .NET 9 SDK
- SQL Server or LocalDB

### Setup

1. Clone the repository
2. Navigate to the Infrastructure project:
   ```bash
   cd src/Infrastructure
   ```

3. Update database:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open browser to `https://localhost:44325` (redirects to Swagger UI)

## API Endpoints

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product

## Database

The application uses SQL Server LocalDB by default. Connection string is configured in `appsettings.json`.

## Project Structure

```
src/
├── Domain/           # Entities, interfaces
├── Application/      # Business logic, CQRS
├── Infrastructure/   # Data access, repositories
└── WebAPI/          # Controllers, configuration
```
