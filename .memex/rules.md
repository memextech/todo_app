# .NET Core Todo Application Setup Guide

## Prerequisites
1. Install .NET Core SDK
```bash
brew install dotnet
```

2. Install Entity Framework Core tools
```bash
dotnet tool install --global dotnet-ef
```

3. Install LibMan CLI
```bash
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

4. Environment Setup
```bash
# Add to ~/.zprofile or ~/.zshrc
export DOTNET_ROOT="/opt/homebrew/opt/dotnet/libexec"
export PATH="$PATH:/Users/<localuser>/.dotnet/tools"
```

## 1. Create API Project
```bash
dotnet new webapi -n TodoApi
cd TodoApi
```

### Install Required Packages
```bash
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```

### Database Setup
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 2. Create Web Frontend
```bash
dotnet new mvc -n TodoWeb
cd TodoWeb
```

### Install Frontend Dependencies
1. Create libman.json for client-side libraries:
```json
{
  "version": "1.0",
  "defaultProvider": "cdnjs",
  "libraries": [
    {
      "library": "bootstrap@5.3.2",
      "destination": "wwwroot/lib/bootstrap/",
      "files": [
        "css/bootstrap.min.css",
        "js/bootstrap.bundle.min.js"
      ]
    },
    {
      "library": "jquery@3.7.1",
      "destination": "wwwroot/lib/jquery/",
      "files": [
        "jquery.min.js",
        "jquery.js"
      ]
    },
    {
      "library": "jquery-validate@1.19.5",
      "destination": "wwwroot/lib/jquery-validation/",
      "files": [
        "jquery.validate.min.js",
        "jquery.validate.js"
      ]
    },
    {
      "library": "jquery-validation-unobtrusive@4.0.0",
      "destination": "wwwroot/lib/jquery-validation-unobtrusive/",
        "files": [
          "jquery.validate.unobtrusive.min.js"
        ]
    }
  ]
}
```

2. Restore client-side libraries:
```bash
libman restore
```

3. Add Tailwind CSS via CDN in _Layout.cshtml:
```html
<script src="https://cdn.tailwindcss.com"></script>
<script>
    tailwind.config = {
        theme: {
            extend: {
                colors: {
                    primary: '#3b82f6',
                }
            }
        }
    }
</script>
```

### Key Components
1. **Models/Todo.cs** - Todo model matching API
2. **Controllers/TodoController.cs** - MVC controller with API client
3. **Views/Todo/**
   - Index.cshtml - Task list with Tailwind styling
   - Create.cshtml - Create form with Tailwind styling
4. **Views/Shared/_Layout.cshtml** - Base layout with Tailwind configuration


### Runing the app

# Stop any existing dotnet processes
pkill -f "dotnet" && echo "Stopped all processes" && \

# Start API and redirect output to api.log
cd project_folder/TodoApi && ASPNETCORE_ENVIRONMENT=Development dotnet run --launch-profile "http" > api.log 2>&1 & echo "API started with PID: $!" && \

# Wait for API to start
sleep 3 && \

# Start Web App with hot reload and redirect output to web.log
cd project_folder/TodoWeb && ASPNETCORE_ENVIRONMENT=Development dotnet watch run --launch-profile "http" > web.log 2>&1 & echo "Web App started with hot reload, PID: $!"

API runs on http://localhost:5200
Swagger UI: http://localhost:5200/swagger

Web app runs on http://localhost:5153

Tell user on which port the app is running before starting

## Important Notes
- Always run API before starting the web app
- Add wwwroot/lib/ to .gitignore
- Use consistent container structure for proper alignment
- Use hot reload during development: `dotnet watch run`