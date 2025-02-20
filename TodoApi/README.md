# .NET Core Todo Application

A modern task management application built with .NET Core, featuring a REST API backend and an MVC frontend with a clean, responsive design.

## Prerequisites

1. Install .NET Core SDK:
```bash
brew install dotnet
```

2. Install Entity Framework Core tools:
```bash
dotnet tool install --global dotnet-ef
```

3. Add .NET tools to PATH:
```bash
export DOTNET_ROOT="/opt/homebrew/opt/dotnet/libexec"
export PATH="$PATH:/Users/marcin/.dotnet/tools"
```

## Project Structure

### 1. API (TodoApi)
- REST API with SQLite database
- Swagger documentation
- CORS enabled

#### Setup
```bash
cd TodoApi
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```

#### Database Setup
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Key Components
- `Models/Todo.cs` - Data model
- `Data/TodoContext.cs` - SQLite context
- `Controllers/TodoController.cs` - API endpoints
- `Program.cs` - App configuration

### 2. Web Frontend (TodoWeb)
- MVC application
- Modern UI with Tailwind CSS
- Responsive design

#### Key Components
- `Models/Todo.cs` - Todo model
- `Controllers/TodoController.cs` - MVC controller
- `Views/Todo/`
  - `Index.cshtml` - Task list
  - `Create.cshtml` - Create form
- `Views/Home/Contact.cshtml` - Contact page

## Running the Application

1. Start the API:
```bash
cd TodoApi
dotnet run --launch-profile "http"
```
API runs on http://localhost:5200
Swagger UI: http://localhost:5200/swagger

2. Start the Web App:
```bash
cd TodoWeb
dotnet run
```
Web app runs on http://localhost:5153

## Features

### API Endpoints
- GET /api/Todo - Get all todos
- GET /api/Todo/{id} - Get specific todo
- POST /api/Todo - Create todo
- PUT /api/Todo/{id} - Update todo
- DELETE /api/Todo/{id} - Delete todo

### Web Interface
- Clean, modern design with Tailwind CSS
- Responsive layout
- Task management:
  - Create new tasks
  - Mark tasks as complete/incomplete
  - Delete tasks
- Contact form
- Consistent styling across pages

## Design Decisions

### Frontend
- Used Tailwind CSS for modern, utility-first styling
- Consistent container structure:
  - `max-w-7xl` for main containers
  - `max-w-4xl` for content areas
  - Consistent padding with `px-6 lg:px-8`
- Responsive design that works on all screen sizes
- Interactive elements with hover states and transitions

### Backend
- SQLite for simple, file-based database
- Entity Framework Core for ORM
- Swagger for API documentation
- CORS enabled for local development

## Notes
- SQLite database file: todos.db
- Development environment variables in appsettings.Development.json
- Frontend assumes API is running on port 5200