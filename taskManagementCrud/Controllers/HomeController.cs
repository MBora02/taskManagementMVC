using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using taskManagementCrud.Models;
using taskManagementCrud.Models.viewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace taskManagementCrud.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var isUserAdmin = User.IsInRole("Admin");

            var viewModel = new HomeDashboardVM
            {
                TotalEmployees = _context.Employees.Count(),
                TotalDepartments = _context.Departments.Count(),
                Employees = _context.Employees.Include(e => e.Department).ToList(),
                Departments = _context.Departments.ToList()
            };

            if (isUserAdmin)
            {
                viewModel.TotalTasks = _context.TaskItems.Count();
                viewModel.TotalProjects = _context.Projects.Count();
                viewModel.Tasks = _context.TaskItems
                    .Include(t => t.Employee)
                    .Include(t => t.Project)
                    .ToList();
                viewModel.Projects = _context.Projects
                    .Include(p => p.Department)
                    .Include(p => p.Employee)
                    .ToList();
            }
            else
            {
                if (int.TryParse(userIdClaim, out int userId))
                {
                    var currentUser = _context.Users.Find(userId);
                    if (currentUser != null)
                    {
                        var employee = _context.Employees.FirstOrDefault(e => 
                            e.EmployeeName == currentUser.Name && 
                            e.EmployeeSurname == currentUser.Surname);

                        if (employee != null)
                        {
                            viewModel.Tasks = _context.TaskItems
                                .Include(t => t.Employee)
                                .Include(t => t.Project)
                                .Where(t => t.EmployeeId == employee.EmployeId)
                                .ToList();
                            
                            viewModel.Projects = _context.Projects
                                .Include(p => p.Department)
                                .Include(p => p.Employee)
                                .Where(p => p.EmployeeId == employee.EmployeId)
                                .ToList();
                        }
                    }
                }

                viewModel.TotalTasks = viewModel.Tasks.Count;
                viewModel.TotalProjects = viewModel.Projects.Count;
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
