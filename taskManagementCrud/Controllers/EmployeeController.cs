using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using taskManagementCrud.Models;
using Microsoft.AspNetCore.Authorization;

namespace taskManagementCrud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        //  LIST
        public IActionResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .ToList();

            return View(employees);
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

            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName"
            );

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound();

            ViewBag.Departments = new SelectList(
                _context.Departments,
                "DepartmentId",
                "DepartmentName",
                employee.DepartmentId // seçili gelsin
            );

            return View(employee);
        }
        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            var employees = _context.Employees
                .Include(x => x.Department)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                employees = employees.Where(x =>
                    x.EmployeeName.Contains(search) ||
                    x.EmployeeSurname.Contains(search));
            }

            return View("Index", employees.ToList());
        }
    }
}