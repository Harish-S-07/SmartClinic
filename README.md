# 🏥 SmartClinic - Backend API

SmartClinic is a scalable hospital management system built with .NET Core using Clean Architecture. It focuses on key modules like authentication, doctor and patient management, appointment scheduling, and billing. The backend demonstrates best practices in modular design, secure authentication, and role-based access control.

## 📁 Project Structure

- **SmartClinic.API** - Entry point (controllers, middleware, startup)
- **SmartClinic.Application** - Business logic, services, DTOs
- **SmartClinic.Domain** - Core models and enums
- **SmartClinic.Infrastructure** - EF Core, DB context, data access
- **SmartClinic.Tests** - Unit tests using xUnit

## 👥 Stakeholders & Roles

- **Admin**: Full control over users, doctors, and appointments
- **Doctor**: View appointments and patient records
- **Receptionist**: Manage scheduling and assist in patient registration
- **Patient**: (Login functionality planned for future)

## ✅ Implemented Features

- **Authentication**
  - JWT-based login and registration
  - Password hashing with BCrypt
  - Role-based access using [Authorize]

- **Doctor Module**
  - Full CRUD operations
  - PATCH support for status updates
  - Soft delete with `IsActive` flag
  - DTO mapping via AutoMapper

- **User Module**
  - Secure Admin-only access
  - Role-based authorization

- **EF Core Integration**
  - Configured `SmartClinicDbContext` with SQL Server
  - Migrations for schema creation
  - Stable database connectivity

- **Testing**
  - Endpoints tested with Postman and Swagger
  - Protected routes return 401 if unauthorized

## 🔐 Security & JWT

- Strong 32+ character JWT secret key
- Configured in `appsettings.json`
- JWT middleware registered in `Program.cs`
- Secure role-based endpoint protection

## 🚧 Swagger

- Swagger UI enabled for API testing
- JWT integration attempted (currently disabled for stability)

## ⚙️ Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio / VS Code

### Setup Instructions

1. Clone the repository  

2. Navigate to project folder  
   `cd SmartClinic`

3. Update connection string in `appsettings.json`

4. Apply EF Core migrations  
   `dotnet ef database update --project SmartClinic.Infrastructure`

5. Run the API  
   `dotnet run --project SmartClinic.API`

6. Test endpoints via Swagger at `https://localhost:{port}/swagger`

## 🛠 Tech Stack

- Backend: .NET 8 (C#)
- Architecture: Clean Architecture
- Database: SQL Server, Entity Framework Core
- Authentication: JWT, BCrypt
- Testing: Swagger, Postman, xUnit
- DevOps: Azure & GitHub Actions
- Version Control: Git + GitHub

## 🚀 Project Status

- ✅ Auth, User, and Doctor modules complete
- ✅ JWT-based auth and role protection in place
- ✅ Stable API tested with Swagger/Postman
- 🔄 Upcoming: Appointments, Billing, JWT-Swagger integration, Azure deployment

## 👨‍💻 Author

**[Harish Shanmugavelan]**  
.NET Backend Developer (1.5+ years experience)  
📧 iharish7810@gmail.com  
🔗 [GitHub](https://github.com/Harish-07) • [LinkedIn](https://www.linkedin.com/in/harish-s-0887681ab)