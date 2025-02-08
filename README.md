# Job Portal API

This project is a **Job Portal Web API** built using **ASP.NET Core**, following the **Clean Architecture** approach. The API provides a scalable and maintainable backend solution for job seekers and recruiters, integrating both **Entity Framework Core** for write operations and **Dapper** for optimized read queries.

---

## Features

- **User Authentication & Authorization:** Secure authentication using ASP.NET Identity and role-based authorization.
- **Job Posting & Management:** Create, read, update, and delete job postings.
- **Job Applications:** Allow job seekers to apply for jobs and track their applications.
- **Hybrid Database Access:** Uses **Entity Framework Core** for write operations and **Dapper** for optimized read queries.
- **Clean Architecture:** Ensures separation of concerns with distinct layers for Domain, Application, Infrastructure, and API.
- **SOLID Principles:** Designed for maintainability and scalability.

---

## Technologies Used

- **Framework:** ASP.NET Core
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Micro-ORM:** Dapper (for read queries)
- **Authentication:** ASP.NET Identity with JWT Authentication
- **Logging:** Serilog

---

## Project Structure

The project follows the **Clean Architecture** pattern with the following layers:

1. **Domain:** Contains core entities, enums, and interfaces.
2. **Application:** Includes business logic such as use cases and service interfaces.
3. **Infrastructure:** Handles database access, third-party services, and repository implementations.
4. **API:** The entry point for clients, managing HTTP requests and responses.