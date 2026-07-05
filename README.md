# Task Management MVC

![.NET Version](https://img.shields.io/badge/.NET-10.0-blue)
![Database](https://img.shields.io/badge/Database-SQL%20Server-red)
![Architecture](https://img.shields.io/badge/Architecture-MVC-green)

A relational database task management system designed to coordinate projects, employees, and departments. The application provides role-based access for system administrators and standard employees, supporting operations tracking and reporting tools.

---

## 🛠️ Technology Stack

| Component | Technology | Version / Details |
| :--- | :--- | :--- |
| **Core Language & Framework** | C# / ASP.NET Core MVC | .NET 10.0 |
| **Database & ORM** | MS SQL Server / Entity Framework Core | EF Core 10.0.9 |
| **User Interface Template** | SB Admin 2 | Bootstrap 4 based responsive theme |
| **Icon Set** | FontAwesome | Vector icons |
| **Excel Export Library** | EPPlus | 8.6.1 |
| **PDF Generation Library** | QuestPDF | 2026.6.1 |

---

## ✨ Key Features

* **Role-Based Access Control (RBAC)**: Separates functions between `Admin` and `User` roles using ASP.NET Core cookie authentication middleware.
* **Unified Admin Dashboard**: Displays total resource metrics and provides quick navigation to management modules.
* **Personalized Employee Portals**: Standard users see only their assigned projects and tasks upon login.
* **Departmental CRUD & Reports**: Allows creation and editing of departments, with features to search names and export list views to PDF and Excel.
* **Employee Directory**: Records employee demographic data, contact numbers, and departmental associations.
* **Project Scheduler**: Assigns projects to departments, registers lead personnel, and defines development timelines.
* **Task Tracker**: Creates individual tasks, maps them to projects, and delegates assignments to employees.
* **Statistical Reports**: Provides consolidated metrics such as employee count rankings by department, task counts per project, and project durations.

### Interface Screenshot Placeholders

#### User Authentication
![Login Interface](https://github-production-user-asset-6213.png)
*Instruction: Upload a screenshot of the login form located at `/Account/Login` here.*

#### System Dashboard
![Admin Dashboard](https://github-production-user-asset-6214.png)
*Instruction: Upload a screenshot of the main admin dashboard showing counts and activity tables here.*

#### Department Management Grid
![Departments List](https://github-production-user-asset-6215.png)
*Instruction: Upload a screenshot of the department index table showing the PDF/Excel download controls here.*

#### Analytical Reports Portal
![Reports Overview](https://github-production-user-asset-6216.png)
*Instruction: Upload a screenshot of the reports page displaying current query datasets here.*

---

## 🏗️ Architecture & Folder Structure

The project implements the Model-View-Controller (MVC) architectural pattern. It organizes application components into defined layers for data access, business models, controller endpoints, and Razor templates.

```text
taskManagementCrud/                     # Repository Root Workspace
├── taskManagementCrud/                 # Main ASP.NET Core Project Directory
│   ├── Controllers/                    # MVC Controllers handling requests and responses
│   ├── Migrations/                     # Entity Framework Core migration history
│   ├── Models/                         # Database entities and data transfer ViewModels
│   ├── Views/                          # Razor pages (.cshtml views and layouts)
│   ├── wwwroot/                        # Static client-side assets (CSS, JS, SB Admin libs)
│   ├── PasswordHelper.cs               # Encryption helper for user password hashing
│   ├── Program.cs                      # Project initialization and middleware pipeline
│   ├── appsettings.json                # Main configuration settings and connection strings
│   └── taskManagementCrud.csproj       # Project build configurations
├── taskManagementCrud.slnx             # Visual Studio solution file
└── README.md                           # Documentation file
```

---

## ⚙️ Setup & Installation Guide

### Prerequisites
* **.NET SDK**: version 10.0 or newer
* **SQL Server**: LocalDB or Express instance
* **EF Core CLI**: `dotnet-ef` global tool (install with `dotnet tool install --global dotnet-ef`)

### Database Connection String Configuration
1. Open `taskManagementCrud/appsettings.json`.
2. Modify the connection string under `ConnectionStrings.DefaultConnection` to match your local database instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TaskManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

### Running Database Migrations
Create the local SQL database and apply schema structures using Entity Framework Core tools:
```powershell
# Navigate into the project folder
cd taskManagementCrud

# Apply the migrations
dotnet ef database update
```

### Building and Launching the Application
1. Compile the project files:
   ```powershell
   dotnet build
   ```
2. Start the web application:
   ```powershell
   dotnet run
   ```
3. Open your web browser and navigate to the address listed in your terminal output (typically `https://localhost:7068` or `http://localhost:5068`).

### Default Test Credentials
The database automatically seeds two test accounts upon initial startup if no user records exist:

> [!IMPORTANT]
> Change the default passwords in a production environment.

| Role | Email Address | Password |
| :--- | :--- | :--- |
| **Administrator** | `admin@task.com` | `admin` |
| **Standard User** | `user@task.com` | `user` |

---

## 📄 License & Attribution

This project is licensed under the MIT License. See the LICENSE file for details.
This project uses the [SB Admin 2](https://github.com/startbootstrap/startbootstrap-sb-admin-2) dashboard template for interface layout.
