# Todo Items API

Welcome to the Todo Items API. This is a robust backend service built with C# using the ASP.NET framework. Designed to support the "Todo Items" frontend application, this API facilitates reliable and secure task management operations.

## Features

- **CRUD Operations**: Comprehensive endpoints for creating, reading, updating, and deleting todo items.
- **Swagger Documentation**: Interactive API documentation and testing using Swagger.
- **Error Handling**: Middleware to gracefully handle exceptions and return standardized error responses.

## Getting Started

### Prerequisites

- .NET 5.0 or later
- Visual Studio 2019 or later

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/YourUsername/todo-items-api.git
   ```

2. Open the solution (`TodoItemsAPI.sln`) in Visual Studio.

3. Use Entity Framework Core to run the migrations and create the database:
   ```sh
   dotnet ef database update
   ```

4. Build and run the solution in Visual Studio. Alternatively, navigate to the project directory in a terminal and run:
   ```sh
   dotnet run
   ```

The API should now be running on `https://localhost:5001`.

## Usage

Access the Swagger UI to view all available endpoints, their descriptions, and to test the API:
```
https://localhost:5001/swagger
```

## Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change. Ensure that your code follows the established coding standards and that all tests pass.

## License

This project is licensed under the MIT License.

