# Hospital Management System API

This project is a Hospital Management System API built using ASP.NET Core, Entity Framework Core, and the Repository pattern. It manages doctors, patients, appointments, diseases, and users within a hospital. JWT (JSON Web Token) is used for authentication and authorization, with roles applied for user management.

## Features

- **RESTful API**: CRUD operations with Get, Post, Put, Patch, and Delete endpoints.
- **Authentication and Authorization**: JWT-based authentication, user management using ASP.NET Core Identity or a custom user entity.
- **Many-to-Many Relationships**: Many-to-many relationships between Patients-Doctors and Patients-Diseases.
- **Repository Pattern**: Database operations abstracted through the repository pattern.
- **Service Layer**: Business logic is handled by Service classes.
- **Action Filters and Middleware**: Global middleware and action filters for logging and error handling.
- **Model Validation**: Validation of incoming data.
- **Dependency Injection**: DI for all services and repositories.
- **Data Protection**: Securing sensitive information with data protection.
- **Global Exception Handling**: Application-wide error handling and meaningful error responses.

## Requirements

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or any supported database by Entity Framework Core)
- Postman or another API client (optional, for testing)

## Setup

### 1. Clone the Repository

```bash
git clone https://github.com/username/hospital-management-api.git
cd hospital-management-api
```

### 2. Install Dependencies

```bash
dotnet restore
```

### 3. Configure Database

Update the database connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HospitalDb;User Id=yourusername;Password=yourpassword;"
  },
  "Jwt": {
    "Secret": "your_jwt_secret_key"
  }
}
```

- **`DefaultConnection`**: Should contain your database server details and credentials.
- **`Jwt:Secret`**: A strong secret key for JWT (e.g., `SuperSecretKey123!@#`).

### 4. Apply Database Migrations

After defining the entities and relationships, run the following commands to create the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will set up the database and create the required tables.

## Usage

### Running the Project

Run the project with:

```bash
dotnet run
```

### API Endpoints

#### Authentication

1. **Register**: `POST /api/auth/register`
2. **Login**: `POST /api/auth/login`

#### Doctors

- `GET /api/doctors` - List all doctors
- `GET /api/doctors/{id}` - Get a specific doctor
- `POST /api/doctors` - Add a new doctor
- `PUT /api/doctors/{id}` - Update an existing doctor
- `DELETE /api/doctors/{id}` - Delete a doctor

#### Patients

- `GET /api/patients` - List all patients
- `GET /api/patients/{id}` - Get a specific patient
- `POST /api/patients` - Add a new patient
- `PUT /api/patients/{id}` - Update an existing patient
- `DELETE /api/patients/{id}` - Delete a patient

#### Appointments

- `GET /api/appointments` - List all appointments
- `GET /api/appointments/{id}` - Get a specific appointment
- `POST /api/appointments` - Add a new appointment
- `PUT /api/appointments/{id}` - Update an existing appointment
- `DELETE /api/appointments/{id}` - Delete an appointment

#### Diseases

- `GET /api/diseases` - List all diseases
- `GET /api/diseases/{id}` - Get a specific disease
- `POST /api/diseases` - Add a new disease
- `PUT /api/diseases/{id}` - Update an existing disease
- `DELETE /api/diseases/{id}` - Delete a disease

## Project Structure

```plaintext
HospitalManagementAPI/
├── Controllers/          # Controllers for API endpoints
├── Entities/             # Entities representing database tables
├── Configurations/       # EF Core configurations
├── Services/             # Service classes containing business logic
├── Repositories/         # Repository classes for data access
├── DTOs/                 # Data Transfer Objects (DTOs)
├── Middlewares/          # Global middleware classes
├── Filters/              # Action filter classes
├── Helpers/              # Helper classes (e.g., JWT token generation)
├── HospitalContext.cs    # Database context
├── Program.cs            # Application setup and configuration
└── Startup.cs            # Dependency injection configuration
```

## Technologies

- **ASP.NET Core**: For Web API development
- **Entity Framework Core**: ORM for database management
- **JWT**: For authentication and authorization
- **Repository Pattern**: Abstraction of data access logic
- **Action Filters and Middleware**: For logging and error management
- **Data Protection**: For data security

