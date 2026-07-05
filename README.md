Task Management System (MVC)
A robust, enterprise-ready Task and Project Management Web Application built with ASP.NET Core MVC (.NET 10.0) and Entity Framework Core. It features role-based access control, rich administrative panels, dynamic database reporting, and document exporting capabilities (PDF & Excel).

1. Project Overview & Key Features
The Task Management System provides organizations with a centralized hub to coordinate work, manage human resources, schedule projects, and track individual tasks. The application distinguishes between two primary roles: Administrators (who oversee all departments, employee roles, projects, tasks, and reports) and Standard Users (who receive a tailored dashboard containing only their assigned workloads).

Key Features
Role-Based Security: Built-in authentication using ASP.NET Core Cookie Authentication. Permissions are strictly enforced across controllers.
Interactive Analytics Dashboard: A modern, statistics-driven homepage powered by the SB Admin 2 dashboard template. Displays key metrics such as total staff, active projects, department counts, and tasks.
Personalized Workspaces: Standard users see a filtered version of the dashboard focusing strictly on the tasks and projects assigned to them.
Department Administration: CRUD interface to register, modify, search, or delete departments.
Employee Management: Detailed directory records containing names, age, gender, contact details, and department allocations.
Project Scheduling: Track project details, target deadlines (weeks), and assign department-level ownership and leading managers.
Granular Task Tracking: Assign distinct project-specific tasks to individual employees.
Reports & Query Visualizations: A dedicated reports area displaying complex database joins and aggregation summaries:
Department-to-Project ratios.
Top employees by task load.
Project manager allocations.
Project durations (longest to shortest).
Employee demographic insights (age rankings).
Document Exporting:
Excel Export: Generates professional Excel sheets utilizing EPPlus with customized styling, header colors, and automated column width adjustments.
PDF Export: Generates clean A4 document reports utilizing QuestPDF containing custom tables, headers, and footer page numbering.
2. Interface Screenshots & Placeholders
Below are inline placeholders for the key screens of the application. Please capture screenshots matching the instructions below each placeholder and save them in the ./screenshots directory in the project root.

Authentication Page
Login Screen

Instruction: Run the application, navigate to the login page (/Account/Login), and capture the sign-in form. Save the image as login.png.

Admin Dashboard (Home)
Admin Dashboard

Instruction: Log in as admin@task.com. Capture the entire home dashboard showing all statistics cards (Total Employees, Departments, Projects, Tasks) and full project lists. Save the image as admin_dashboard.png.

User Dashboard (Home)
User Dashboard

Instruction: Log in as user@task.com. Capture the filtered homepage demonstrating that only the tasks and projects assigned to "Standard User" are listed. Save the image as user_dashboard.png.

Department Management
Department Management

Instruction: Navigate to the Department index page (/Department). Capture the listing table showing the Search bar, "Export to PDF", and "Export to Excel" buttons. Save the image as departments.png.

Employee Directory
Employee Management

Instruction: Navigate to the Employee list page (/Employee). Capture the list demonstrating the personnel list and their associated departments. Save the image as employees.png.

Project Planner
Project Management

Instruction: Navigate to the Project list page (/Project). Capture the project table view containing details on weeks, personnel size, and project leads. Save the image as projects.png.

Task Board
Task Management

Instruction: Navigate to the Task list page (/TaskItem). Capture the list demonstrating specific tasks linked to employees and projects. Save the image as tasks.png.

Reports & Analytics Dashboard
Reports Page

Instruction: Go to the Reports index page (/Report). Capture the overview page listing the direct links to different analytics views. Save the image as reports.png.

3. Technology Stack
Technology / Library	Role in Project	Version
.NET 10.0 (ASP.NET MVC)	Server-side Application Framework	net10.0
Entity Framework Core	Object-Relational Mapper (ORM)	10.0.9
Microsoft SQL Server	Relational Database Management System	LocalDB / SQLEXPRESS
SB Admin 2 (Bootstrap 4)	Client-side UI Template, Styling, & Layout	CSS3 / HTML5
EPPlus	Excel Spreadsheet Engine	8.6.1 (Community License)
QuestPDF	PDF Generation Engine	2026.6.1 (Community License)
4. Directory Structure Guide
Ensure you place the screenshots folder in the root directory of the workspace as outlined below:

text

taskManagementCrud/                      <-- Project Workspace Root
├── taskManagementCrud/                  <-- ASP.NET MVC Project Folder
│   ├── Controllers/                     <-- MVC Controllers (Account, Department, etc.)
│   ├── Migrations/                      <-- EF Core Migrations
│   ├── Models/                          <-- Database Entities and ViewModels
│   ├── Views/                           <-- CSHTML View Templates
│   ├── wwwroot/                         <-- Static Assets (CSS, JS, admin template)
│   ├── appsettings.json                 <-- Configuration file (Database Connection)
│   ├── Program.cs                       <-- App Entry Point and Services Configuration
│   └── taskManagementCrud.csproj        <-- Project Package References
├── screenshots/                         <-- Screenshots Folder (Create this folder)
│   ├── login.png                        <-- Place login screen here
│   ├── admin_dashboard.png              <-- Place admin home screen here
│   ├── user_dashboard.png               <-- Place user home screen here
│   ├── departments.png                  <-- Place departments screen here
│   ├── employees.png                    <-- Place employees screen here
│   ├── projects.png                     <-- Place projects screen here
│   ├── tasks.png                        <-- Place tasks screen here
│   └── reports.png                      <-- Place reports dashboard screen here
├── README.md                            <-- This file
└── taskManagementCrud.slnx              <-- Visual Studio Solution File
5. Setup & Run Guide
Step 1: Clone the Repository
Clone the repository to your local machine:

bash

git clone https://github.com/<your-username>/taskManagementMVC.git
cd taskManagementMVC
Step 2: Configure Database Connection String
Open taskManagementCrud/appsettings.json and adjust the connection string to point to your local Microsoft SQL Server instance:

json

"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TaskManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
(Modify the Server parameter as needed. For LocalDB use: Server=(localdb)\\mssqllocaldb)

Step 3: Run Database Migrations
Generate the database schema on your local SQL Server instance by running the Entity Framework Core migration update command:

bash

# Navigate to the project directory containing the .csproj file
cd taskManagementCrud
# Apply migrations
dotnet ef database update
(Make sure you have the EF Core tools installed globally: dotnet tool install --global dotnet-ef)

Step 4: Run the Application
Start the development web server:

bash

dotnet run
The application will boot and display the listening local ports (usually https://localhost:7214 or similar). Open the address in your preferred web browser.

6. Default Login Credentials
Upon application startup, if the user database is detected as empty, the application seeds the following default accounts. Use these credentials to sign in and test role behaviors:

Administrator Account

Email: admin@task.com
Password: admin
Role: Admin (Full access to CRUD management panels and report generation)
Standard User Account

Email: user@task.com
Password: user
Role: User (Personalized homepage listing only assigned tasks and projects)
7. License
This project is licensed under the MIT License.

Disclaimer: This application uses EPPlus and QuestPDF under their respective Community/Non-Commercial license guidelines.
