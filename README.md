### Prerequisites
-  [.NET Core SDK](https://dotnet.microsoft.com/download)
-  [Entity Framework Core SDK](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)

### Description
This is a web API that performs Create, Read, Update, and Delete (CRUD) operations

### Run migrations
```
dotnet ef database update
```

### Run the project
```bash
dotnet run
```

### Run the project in development
```bash
dotnet watch run
```
### Build the project
```bash
dotnet build
```

### Install nuget packages
```bash
dotnet restore
```

### Run the tests
```bash
dotnet test
```

### Swagger Docs Endpoint
/swagger/
## API Documentation

| Method  | Description| Route |
| ------------- | ------------- | ------------- |
| GET |  Get all todos | `/api/todo` |
| POST | Create a todo | `/api/todo` |
| GET |  Get a specific todo | `/api/todo/:id` |
| PUT |  Update a specific todo | `/api/todo/:id` |
| DELETE | Delete a specific todo |`/api/todo/:id` |

## Author

*   **Ryan Wire** 

## Notes
### Create the database
Run the following todos:
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add "Initial Migrations"
dotnet ef database update
```

### Create a migration
```
dotnet ef migrations add "Initial Migrations"
```
### Undo migrations
```
dotnet ef migrations remove
```