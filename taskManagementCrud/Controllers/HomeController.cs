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
            var viewModel = new HomeDashboardVM
            {
                TotalTasks = _context.TaskItems.Count(),
                TotalProjects = _context.Projects.Count(),
                TotalEmployees = _context.Employees.Count(),
                TotalDepartments = _context.Departments.Count(),
                
                Tasks = _context.TaskItems
                    .Include(t => t.Employee)
                    .Include(t => t.Project)
                    .ToList(),
                
                Projects = _context.Projects
                    .Include(p => p.Department)
                    .Include(p => p.Employee)
                    .ToList(),
                
                Employees = _context.Employees
                    .Include(e => e.Department)
                    .ToList(),
                
                Departments = _context.Departments.ToList()
            };

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
