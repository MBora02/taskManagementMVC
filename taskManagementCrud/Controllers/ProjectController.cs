using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using taskManagementCrud.Models;

namespace taskManagementCrud.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        // LIST (Index)
        public IActionResult Index()
        {
            var projects = _context.Projects
                .Include(p => p.Department)
                .Include(p => p.Employee)
                .ToList();

            return View(projects);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName"
            );

            ViewBag.Employees = new SelectList(
                _context.Employees,
                "EmployeId",
                "EmployeeName"
            );

            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
                return NotFound();

            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName",
                project.DepartmentId
            );

            ViewBag.Employees = new SelectList(
                _context.Employees,
                "EmployeId",
                "EmployeeName",
                project.EmployeeId
            );

            return View(project);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        [HttpPost]
        public IActionResult Delete(Project project)
        {
            _context.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            var projects = _context.Projects
                .Include(x => x.Department)
                .Include(x => x.Employee)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                projects = projects.Where(x =>
                    x.ProjectName.Contains(search));
            }

            return View("Index", projects.ToList());
        }
    }
}