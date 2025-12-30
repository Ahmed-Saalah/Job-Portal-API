# Job Portal API

This project is a **Job Portal Web API** built using **ASP.NET Core**, following the **Clean Architecture** approach. The API provides a scalable and maintainable backend solution for job seekers and recruiters.

---

## Features

- **User Authentication & Authorization:** Secure authentication using ASP.NET Identity and role-based authorization.
- **Job Posting & Management:** Create, read, update, and delete job postings.
- **Job Applications:** Allow job seekers to apply for jobs and track their applications.
- **Clean Architecture:** Ensures separation of concerns with distinct layers for Domain, Application, Infrastructure, and API.
- **SOLID Principles:** Designed for maintainability and scalability.

---

## Technologies Used

- **Framework:** ASP.NET Core
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Identity with JWT Authentication
- **Logging:** Serilog
- **Validation:** Fluent Validation

---

## Project Structure

The project follows the **Clean Architecture** pattern with the following layers:

1. **Domain:** Contains core entities, enums, and interfaces.
2. **Application:** Includes use cases, business logic, and application contracts.
3. **Infrastructure:** Handles database access, EF Core configurations, repositories.
4. **API:** The entry point for clients, managing HTTP requests and responses.

## API Endpoints

### **Authentication**  
- `POST /api/account/register` → Register a new user.  
- `POST /api/account/login` → Authenticate and get a JWT token.  
- `POST /api/account/refreshToken/{refreshToken}` → Refresh JWT token.  

---

### **Jobs**  
- `GET /api/jobs` → Retrieve all jobs.  
- `GET /api/jobs/{id}` → Retrieve a job by its ID.  
- `GET /api/jobs/category/{categoryId}` → Retrieve jobs by category ID.  
- `POST /api/jobs` → Allows recruiters to create a new job.  
- `PUT /api/jobs/{id}` → Allows recruiters to update an existing job.  
- `DELETE /api/jobs/{id}` → Allows recruiters to delete a job.  

---

### **Job Applications**  
- `GET /api/jobapplications/job/{jobId}` → Retrieve all applications for a specific job.  
- `GET /api/jobapplications/user/{userId}/job/{jobId}` → Retrieve a specific user's application for a job.  
- `POST /api/jobapplications` → Allows job seekers to apply for a job.  
- `PUT /api/jobapplications/status` → Allows recruiters to update the application status.  
- `PUT /api/jobapplications` → Allows job seekers to update the application.  
- `DELETE /api/jobapplications/{id}` → Allows job seekers to withdraw their application.  

---
