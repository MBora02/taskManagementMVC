<img width="1912" height="861" alt="image" src="https://github.com/user-attachments/assets/66904cf4-b118-4067-8282-699c9940c96f" /># Task Management MVC

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
<img width="1912" height="861" alt="image" src="https://github.com/user-attachments/assets/c7e63788-b76e-4865-af76-a720078c8d26" />

#### User MainPage
<img width="1902" height="800" alt="image" src="https://github.com/user-attachments/assets/49e50ef1-1480-4042-8aa2-139d1a59150d" />

#### System Dashboard
![Admin Dashboard](https://github-production-user-asset-6214.png)
*Instruction: Upload a screenshot of the main admin dashboard showing counts and activity tables here.*

#### Department Management Grid
<img width="1913" height="855" alt="image" src="https://github.com/user-attachments/assets/4af293d2-8493-47f8-a9d4-b30cb353cefc" />

#### Employee Management Grid
<img width="1910" height="853" alt="image" src="https://github.com/user-attachments/assets/6d20a3e8-642c-4eab-8dea-a5ed5d6b1189" />

#### Project Management Grid
<img width="1911" height="852" alt="image" src="https://github.com/user-attachments/assets/2353efda-fd52-404b-91fe-11d076382aca" />

#### Task Management Grid
<img width="1913" height="847" alt="image" src="https://github.com/user-attachments/assets/417e4df1-c9d3-42ce-a473-ceff89c2b6b8" />


#### Analytical Reports Page
<img width="1910" height="841" alt="image" src="https://github.com/user-attachments/assets/16b8f52e-7675-43dc-865b-45d82c00d64e" />

#### Example Report Page
<img width="1913" height="856" alt="image" src="https://github.com/user-attachments/assets/bc2ec832-2d30-4ef8-9d63-91b179671cc9" />

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
