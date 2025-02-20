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

## Setup and Installation

1. Install prerequisites:
```bash
# Install .NET Core SDK
brew install dotnet

# Install Entity Framework Core tools
dotnet tool install --global dotnet-ef

# Install LibMan CLI
dotnet tool install -g Microsoft.Web.LibraryManager.Cli

# Add to ~/.zprofile or ~/.zshrc
export DOTNET_ROOT="/opt/homebrew/opt/dotnet/libexec"
export PATH="$PATH:/Users/<localuser>/.dotnet/tools"
```

2. Setup API:
```bash
cd TodoApi
dotnet restore
dotnet ef database update
dotnet run --launch-profile "http"
```

3. Setup Web App:
```bash
cd TodoWeb
dotnet restore
libman restore
dotnet run
```

## Development

### Running the Applications
1. Start API (http://localhost:5200):
```bash
cd TodoApi
dotnet run --launch-profile "http"
```

2. Start Web App (http://localhost:5153):
```bash
cd TodoWeb
dotnet watch run
```

### Design System

#### Container Structure
```html
<div class="mx-auto max-w-7xl px-6 lg:px-8">
    <div class="mx-auto max-w-4xl py-8">
        <!-- Content here -->
    </div>
</div>
```

#### Common Components
- Buttons:
```html
<button class="inline-flex items-center px-4 py-2 bg-primary text-white font-semibold rounded-lg shadow-sm hover:bg-blue-700 transition duration-300">
    <!-- Button content -->
</button>
```
- Task Items:
```html
<div class="group hover:bg-gray-50 transition-all duration-200">
    <div class="px-6 py-4 flex items-center justify-between">
        <!-- Task content -->
    </div>
</div>
```

## Git Configuration
```gitignore
# Ignore client-side libraries
**/wwwroot/lib/

# Database files
*.db
*.db-shm
*.db-wal

# Build outputs
bin/
obj/
```

## Notes
- Always run API before starting the web app
- Use hot reload for faster development
- Maintain consistent container structure for proper alignment
- Follow the established design system for new components