# Etiqa Assessment
 
CDN - Complete Developer Network
Overview
CDN - Complete Developer Network is a fictional company that provides a directory of freelancers for various jobs. This project is a RESTful API built using ASP.Net Core Web API that supports user registration, deletion, updating, and retrieval. The API connects to a SQL Server database and is designed following Clean Architecture principles.

Table of Contents

Technologies Used

Architecture

Getting Started

Prerequisites

Installation

Running the Application

API Endpoints

Additional Features

Testing

Deployment

Contributing

License

Technologies Used

ASP.Net Core Web API

Entity Framework Core

SQL Server

Clean Architecture

Dependency Injection

Pagination

Global Error Handling

Unit and Integration Testing with xUnit

CI/CD with GitHub Actions

Architecture

The project follows Clean Architecture principles and is divided into the following layers:

Core: Contains the domain entities and repository interfaces.
Application: Contains the application services (use cases).
Infrastructure: Contains the database context and repository implementations.
API: Contains the Web API controllers and handles HTTP requests.
Project Structure
markdown

/src
  /EtiqAssessment.Application
    - Services
  /EtiqAssessment.Infrastructure
    - Data
    - Repositories
  /EtiqAssessment
    - Controllers
    - Startup.cs
  /tests
    - CDN.UnitTests
    - CDN.IntegrationTests
    
README.md

Getting Started
Prerequisites
.NET Core SDK
SQL Server
Git
Installation
Clone the repository:

git clone https://github.com/your-username/cdn-complete-developer-network.git
cd cdn-complete-developer-network
Set up the database:
Update the connection string in src/EtiqAssessment/appsettings.json.
json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=CDNDB;User Id=sa;Password=Inthedoor@1;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=True;Connection Timeout=30;"
  }
}

Apply migrations:

cd src/EtiqAssessment
dotnet ef database update
Running the Application


cd src/EtiqAssessment
dotnet run
The API will be available at https://localhost:5001 or http://localhost:5000.

API Endpoints
GET /api/users: Retrieve all users.
GET /api/users/{id}: Retrieve a user by ID.
POST /api/users: Register a new user.
PUT /api/users/{id}: Update an existing user.
DELETE /api/users/{id}: Delete a user by ID.
Additional Features
Client-side Development
A simple front-end application built with Angular or React can be created to interact with the API.

Securing the Endpoint
Use JWT authentication to secure the endpoints.

Caching Strategy
Implement caching for frequently accessed data using in-memory caching or distributed caching.

Pagination
Add pagination support to the GET endpoint for retrieving users.


[HttpGet]
public async Task<ActionResult<IEnumerable<User>>> GetUsers(int pageNumber = 1, int pageSize = 10)
{
    return Ok(await _userService.GetAllUsersAsync(pageNumber, pageSize));
}
Global Error Handling
Add middleware for global error handling.

Unit and Integration Testing
Use xUnit for writing unit and integration tests.

Testing
Run the unit and integration tests:

cd tests/EtiqAssessment.UnitTests
dotnet test

cd tests/EtiqAssessment.IntegrationTests
dotnet test
Deployment
Deploy the application to a cloud platform like Heroku, AWS, or Azure.

Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

License
This project is licensed under the MIT License.
