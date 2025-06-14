**SmartClinic - Backend API**

SmartClinic is a scalable hospital management system built with .NET Core using Clean Architecture. It focuses on essential modules such as authentication, doctor and patient management, appointment scheduling. The backend demonstrates best practices in modular design, secure authentication, and role-based access control.

**Project Structure**

- **SmartClinic.API** – Entry point (controllers, middleware, startup)
- **SmartClinic.Application** – Business logic, services, DTOs
- **SmartClinic.Domain** – Core models and enums
- **SmartClinic.Infrastructure** – EF Core, DB context, data access
- **SmartClinic.Tests** – Unit tests using xUnit

**Stakeholders and Roles**

- **Admin** – Full control over users, doctors, and appointments
- **Doctor** – View appointments and patient records
- **Receptionist** – Manage scheduling and assist in patient registration
- **Patient** – Login functionality planned for future updates

**Implemented Features**

**Authentication**

- JWT-based login and registration
- Password hashing with BCrypt
- Role-based access using `[Authorize]` attributes

**Doctor Module**

- Full Create, Read, Update, Delete (CRUD) operations
- PATCH support for status updates
- Soft delete functionality using an `IsActive` flag
- AutoMapper integration for clean DTO mapping

**User Module**

- Secure Admin-only access to manage users
- Role-based authorization for user-related endpoints

**Appointment Module**

- Create, update, and delete appointments
- Retrieve appointments by ID, status, or assigned doctor
- Role-based access for Admin and Receptionist roles
- Enum support for appointment status (e.g., Scheduled, Completed)
- Includes navigation properties for Doctor and Patient

**EF Core Integration**

- SQL Server database configured through `SmartClinicDbContext`
- Entity Framework Core migrations for schema creation and updates
- Reliable and tested database connectivity

**Testing**

- All endpoints tested using Postman and Swagger UI
- Protected routes return appropriate 401 responses for unauthorized access

**Security and JWT**

- Uses a secure 32+ character secret key for JWT
- JWT configuration set up in `appsettings.json`
- Authentication middleware registered in `Program.cs`
- Role-based endpoint protection using standard ASP.NET Core authorization

**Getting Started**

**Prerequisites**

- .NET 8 SDK
- SQL Server
- Visual Studio or Visual Studio Code

**Setup Instructions**

1. Clone the repository
2. Navigate to the project folder:  
   `cd SmartClinic`
3. Update the SQL Server connection string in `appsettings.json`
4. Apply the EF Core migrations:  
   `dotnet ef database update --project SmartClinic.Infrastructure`
5. Run the API:  
   `dotnet run --project SmartClinic.API`
6. Open Swagger UI to test endpoints:  
   `https://localhost:{port}/swagger`

**Tech Stack**

- **Backend:** ASP.NET Core (.NET 8)
- **Architecture:** Clean Architecture
- **Database:** SQL Server, Entity Framework Core
- **Authentication:** JWT, BCrypt
- **Testing:** Swagger, Postman, xUnit
- **DevOps:** Azure Pipelines, GitHub Actions
- **Version Control:** Git and GitHub

**Project Status**

- Authentication, User, Doctor, and Appointment modules are complete
- JWT-based authentication and role protection implemented
- API functionality tested and stable
- Upcoming: Billing module, Swagger-JWT token integration, Azure deployment

**Author**

**Harish Shanmugavelan**  

.NET Backend Developer (1.5+ years experience)  

**Email:** iharish7810@gmail.com  
**GitHub:** [https://github.com/Harish-S-07](https://github.com/Harish-S-07)  
**LinkedIn:** [https://www.linkedin.com/in/harishshanmugavelan](https://www.linkedin.com/in/harishshanmugavelan)