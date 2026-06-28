using Microsoft.AspNetCore.Mvc;
using taskManagementCrud.Models;
using taskManagementCrud.Models.viewModel;

namespace taskManagementCrud.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;
        public ReportController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DepartmentProjectCount()
        {
            var values = _context.Projects
                .GroupBy(x => x.Department.DepartmentName)
                .Select(x => new
                {
                    Department = x.Key,
                    ProjectCount = x.Count()
                })
                .ToList();

            return View(values);
        }

        public IActionResult EmployeeTaskCount()
        {
            var values = _context.TaskItems
                .GroupBy(x => x.Employee.EmployeeName + " " + x.Employee.EmployeeSurname)
                .Select(x => new
                {
                    Employee = x.Key,
                    TaskCount = x.Count()
                })
                .OrderByDescending(x => x.TaskCount)
                .ToList();

            return View(values);
        }

        public IActionResult EmployeeDepartments()
        {
            var values = _context.Employees
                .Select(x => new
                {
                    FullName = x.EmployeeName + " " + x.EmployeeSurname,
                    Department = x.Department.DepartmentName
                })
                .ToList();

            return View(values);
        }

        public IActionResult LongestProjects()
        {
            var values = _context.Projects
                .OrderByDescending(x => x.ProjectTotalWeek)
                .Select(x => new
                {
                    x.ProjectName,
                    x.ProjectTotalWeek
                })
                .ToList();

            return View(values);
        }

        public IActionResult ProjectEmployees()
        {
            var values = _context.Projects
                .Select(x => new
                {
                    x.ProjectName,
                    Employee = x.Employee.EmployeeName + " " + x.Employee.EmployeeSurname
                })
                .ToList();

            return View(values);
        }

        public IActionResult ProjectTaskCount()
        {
            var values = _context.TaskItems
                .GroupBy(x => x.Project.ProjectName)
                .Select(x => new
                {
                    Project = x.Key,
                    TaskCount = x.Count()
                })
                .OrderByDescending(x => x.TaskCount)
                .ToList();

            return View(values);
        }

        public IActionResult TaskEmployees()
        {
            var values = _context.TaskItems
                .Select(x => new
                {
                    x.TaskName,
                    Employee = x.Employee.EmployeeName + " " + x.Employee.EmployeeSurname
                })
                .ToList();

            return View(values);
        }

        public IActionResult DepartmentProjects()
        {
            var values = _context.Projects
                .Select(x => new
                {
                    x.ProjectName,
                    Department = x.Department.DepartmentName
                })
                .ToList();

            return View(values);
        }

        public IActionResult EmployeeAgeRanking()
        {
            var values = _context.Employees
                .OrderByDescending(x => x.EmployeeAge)
                .Select(x => new
                {
                    FullName = x.EmployeeName + " " + x.EmployeeSurname,
                    x.EmployeeAge
                })
                .ToList();

            return View(values);
        }

        public IActionResult EmployeeDepartmentReport()
        {
            var result = from e in _context.Employees
                         join d in _context.Departments
                         on e.DepartmentId equals d.DepartmentId
                         select new EmployeeDepartmentVM
                         {
                             EmployeeName = e.EmployeeName,
                             EmployeeSurname = e.EmployeeSurname,
                             EmployeeAge = e.EmployeeAge,
                             DepartmentName = d.DepartmentName
                         };

            return View(result.ToList());
        }

        public IActionResult EmployeeProjectReport()
        {
            var result = from p in _context.Projects
                         join e in _context.Employees
                         on p.EmployeeId equals e.EmployeId
                         select new EmployeeProjectVM
                         {
                             EmployeeName = e.EmployeeName + " " + e.EmployeeSurname,
                             ProjectName = p.ProjectName,
                             ProjectTotalWeek = p.ProjectTotalWeek,
                             ProjectUserCount = p.ProjectUserCount
                         };

            return View(result.ToList());
        }

        public IActionResult ProjectTaskReport()
        {
            var result = from t in _context.TaskItems
                         join p in _context.Projects
                         on t.ProjectId equals p.ProjectId
                         join e in _context.Employees
                         on t.EmployeeId equals e.EmployeId
                         select new ProjectTaskVM
                         {
                             ProjectName = p.ProjectName,
                             TaskName = t.TaskName,
                             TaskDescription = t.TaskDescription,
                             EmployeeName = e.EmployeeName + " " + e.EmployeeSurname
                         };

            return View(result.ToList());
        }

        public IActionResult DepartmentEmployeeCount()
        {
            var result = from e in _context.Employees
                         join d in _context.Departments
                         on e.DepartmentId equals d.DepartmentId
                         group e by d.DepartmentName into g
                         select new DepartmentEmployeeCountVM
                         {
                             DepartmentName = g.Key,
                             EmployeeCount = g.Count()
                         };

            return View(result.ToList());
        }
    }
}
