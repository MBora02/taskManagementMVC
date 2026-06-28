using Microsoft.AspNetCore.Mvc;
using taskManagementCrud.Models;

namespace taskManagementCrud.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            department = _context.Departments.Find(department.DepartmentId);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string search)
        {
            var departments = _context.Departments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                departments = departments.Where(x =>
                    x.DepartmentName.Contains(search));
            }

            return View("Index", departments.ToList());
        }
    
    }
}
