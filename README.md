# Travel Guide Blogs - Clean Architecture
<br/>

A modern ASP.NET Core Web API built with Clean Architecture principles for operation venue management.

## Features

- [x] Built on .NET 8.0
- [x] Follows Clean Architecture Principles
- [x] MSSQL Database Support
- [x] Entity Framework Core
- [x] JWT Authentication
- [x] RESTful API Design
- [x] Dependency Injection
- [x] Unit Testing Support

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- MSSQL Server

## Overview

### Domain

Note that the Domain project does not depend on any other project other than the Shared project.

As per Clean Architecture principles, the Core of this Solution i.e, Application and Domain projects do not depend on any other projects. This helps achieve Dependency Inversion (The ‘D’ Principle of ‘SOLID’).

### Application

This is the Application layer that contains business logic and application services. It defines interfaces that are implemented in the Infrastructure layer, following the Dependency Inversion principle.

```
├── Core
│   ├── Application
│   │   ├── Common
│   │   ├── Cqrs
│   │   ├── Dto
│   │   ├── Identity
│   │   └── Interfaces
```

The folders and split at the top level Feature-wise. Meaning, it now makes it easier for developers to understand the folder structure. Each of the feature folders like Catalog will have all the files related to it’s scope including validators, dtos, interfaces and so on.

Thus everything related to a feature will be found directly under that Feature folder.

In cases where there are less number of classes / interfaces associated with a feature, all of these classes are put directly under the root of the feature folder. Only when the complexity of the feature increases, it is recommended to separate the classes by their type.

Note that the Application project depends only on the Core projects which are Shared and Domain.

### Infrastructure

The Infrastructure layer contains the implementation of interfaces defined in the Application layer. This layer handles external concerns such as:

- **Entity Framework Core**: Database access and ORM
- **Authentication**: JWT token generation and validation

This layer follows the Dependency Inversion principle by implementing abstractions defined in the Application layer.

### Host (Presentation Layer)

The Host project serves as the entry point of the application and contains:

- **API Controllers**: RESTful endpoints for client communication
- **Startup Configuration**: Dependency injection container setup
- **Middleware Pipeline**: Request/response processing pipeline
- **Configuration Files**: Application settings and environment-specific configs

**Dependencies:**

- Application Layer
- Infrastructure Layer
- Migration Projects

## Installation & Setup

### Prerequisites

Ensure you have the following installed:

- .NET 8.0 SDK (for local development)

### Local Development Setup

If you prefer to run the application locally without Docker:

1. **Setup Database**

   - Install SQL Server or use SQL Server Express
   - Update connection string in `appsettings.Development.json`

2. **Build Project**

   ```bash
   dotnet build
   ```

3. **Run Database Migrations**

   ```bash
   dotnet ef database update --project src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.Migrators
   ```

4. **Run the Application**
   ```bash
   dotnet run --project src/TravelBlogs.Presentation/TravelBlogs.Presentation.Host
   ```

## Project Structure

```
├── src/
│   ├── Core/
│   │   ├── Application/          # Business logic and interfaces
│   │   ├── Domain/              # Domain entities and business rules
│   │   └── Shared/              # Shared components
│   ├── Infrastructures/
│   │   ├── Infrastructure/       # Cross-cutting concerns
│   │   ├── Persistence/         # Data access layer
│   │   └── Migrators/           # Database migrations
│   └── Presentation/
│       └── Host/                # Web API controllers
├── test/
    └── UnitTest/                # Unit tests

```

## Testing

Run unit tests using:

```bash
dotnet test
```

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## Support

If this project has helped you learn something new or assisted you at work, consider:

- ⭐ **Star this repository**
- 🐛 **Report issues**
- 💡 **Suggest improvements**
- 🤝 **Contribute to the project**

## Technologies Used

- **.NET 8.0**: Modern cross-platform framework
- **Entity Framework Core**: Object-relational mapping
- **SQL Server**: Relational database
- **Swagger/OpenAPI**: API documentation
- **xUnit**: Unit testing framework
- **Clean Architecture**: Architectural pattern
- **CQRS**: Command Query Responsibility Segregation

---

**Made with ❤️ by the development team**
