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

## API Endpoints

### **Authentication**  
- `POST /api/account/register` → Register a new user.  
- `POST /api/account/login` → Authenticate and get a JWT token.  
- `POST /api/account/refreshToken/{refreshToken}` → Refresh JWT token.  

---

### **Jobs**  
- `GET /api/jobs` → Retrieve all jobs (Dapper).  
- `GET /api/jobs/{id}` → Retrieve a job by its ID (Dapper).  
- `GET /api/jobs/category/{categoryId}` → Retrieve jobs by category ID (Dapper).  
- `POST /api/jobs` → Allows recruiters to create a new job (EF).  
- `PUT /api/jobs/{id}` → Allows recruiters to update an existing job (EF).  
- `DELETE /api/jobs/{id}` → Allows recruiters to delete a job (EF).  

---

### **Job Applications**  
- `GET /api/jobapplications/job/{jobId}` → Retrieve all applications for a specific job (Dapper).  
- `GET /api/jobapplications/user/{userId}/job/{jobId}` → Retrieve a specific user's application for a job (Dapper).  
- `POST /api/jobapplications` → Allows job seekers to apply for a job (EF).  
- `PUT /api/jobapplications/update-status-by-recruiter` → Allows recruiters to update the application status (EF).  
- `PUT /api/jobapplications/update-job-application` → Allows job seekers to update the application (EF).  
- `DELETE /api/jobapplications/{id}` → Allows job seekers to withdraw their application (EF).  

---
