# .NET Core Todo Application

A modern task management application built with .NET Core, featuring a REST API backend and an MVC frontend with a clean, responsive design using Tailwind CSS.

## Features

### API
- REST API with SQLite database
- Swagger documentation
- CORS enabled
- Entity Framework Core for data access

### Web Interface
- Modern, responsive design with Tailwind CSS
- Client-side libraries managed with LibMan
- Task management:
  - Create new tasks
  - Mark tasks as complete/incomplete
  - Delete tasks
- Contact page with form

## Project Structure

### TodoApi
- REST API with SQLite
- Endpoints:
  - GET /api/Todo - Get all todos
  - GET /api/Todo/{id} - Get specific todo
  - POST /api/Todo - Create todo
  - PUT /api/Todo/{id} - Update todo
  - DELETE /api/Todo/{id} - Delete todo

### TodoWeb
- MVC frontend application
- Views:
  - Tasks list with modern UI
  - Create task form
  - Contact page
- Consistent styling with Tailwind CSS