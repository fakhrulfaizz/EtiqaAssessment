# EtiqAssessment

EtiqAssessment is a RESTful API built with ASP.Net Core Web API that manages a list of freelancers. The project demonstrates a clean architecture approach and includes CRUD operations for freelancer management.

## Features

- Register a new freelancer
- Update freelancer details
- Delete a freelancer
- Get a list of freelancers
- Pagination, Error Handling, and Input Validation
- CORS enabled for cross-origin requests

## Technologies Used

- ASP.Net Core Web API
- Entity Framework Core
- SQL Server (running in Docker)
- Angular for front-end
- Swagger for API documentation
- Clean Architecture principles

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [Docker](https://www.docker.com/)

### Setting Up the Backend

1. Clone the repository:
    ```bash
    git clone https://github.com/fakhrulfaizz/EtiqAssessment.git
    cd EtiqAssessment
    ```

2. Build and run the SQL Server container:
    ```bash
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Inthedoor@1' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
    ```

3. Set up the database:
    - Ensure your connection string in `appsettings.json` is correct.
    - Apply migrations and update the database:
      ```bash
      dotnet ef database update
      ```

4. Run the backend:
    ```bash
    dotnet run --project EtiqAssessment.API
    ```

5. Open your browser and navigate to `http://localhost:5000/swagger` to see the Swagger UI.

### Setting Up the Frontend

1. Navigate to the Angular project directory:
    ```bash
    cd EtiqAssessment.Angular
    ```

2. Install the dependencies:
    ```bash
    npm install
    ```

3. Run the Angular development server:
    ```bash
    ng serve
    ```

4. Open your browser and navigate to `http://localhost:4200` to see the frontend application.

## API Endpoints

### Freelancers

- `GET /api/freelancers`: Get a list of freelancers.
- `POST /api/freelancers`: Create a new freelancer.
- `PUT /api/freelancers/{id}`: Update a freelancer.
- `DELETE /api/freelancers/{id}`: Delete a freelancer.

## Directory Structure

EtiqAssessment/&nbsp;&nbsp;&nbsp;&nbsp;  
│  
├── EtiqAssessment/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Controllers/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Models/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Services/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── CleanApp/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── src/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── app/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── components/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── services/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── ...  
│  
├── EtiqAssessment.Application/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Interfaces/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Services/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── ...  
│  
├── EtiqAssessment.Domain/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Entities/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Interfaces/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── ...  
│  
├── EtiqAssessment.Infrastructure/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Data/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;├── Repositories/  
│&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;└── ...  
│    
│  
└── README.md  

## Contributing

If you want to contribute to this project, please fork the repository and create a pull request.

## License

This project is licensed under the MIT License.

