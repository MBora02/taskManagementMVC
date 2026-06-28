using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using taskManagementCrud.Models;

namespace taskManagementCrud.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly AppDbContext _context;

        public TaskItemController(AppDbContext context)
        {
            _context = context;
        }

        // LIST (Index)
        public IActionResult Index()
        {
            var tasks = _context.TaskItems
                .Include(t => t.Employee)
                .Include(t => t.Project)
                .ToList();

            return View(tasks);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(
                _context.Employees,
                "EmployeId",
                "EmployeeName"
            );

            ViewBag.Projects = new SelectList(
                _context.Projects,
                "ProjectId",
                "ProjectName"
            );

            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.TaskItems.Find(id);

            if (task == null)
                return NotFound();

            ViewBag.Employees = new SelectList(
                _context.Employees,
                "EmployeId",
                "EmployeeName",
                task.EmployeeId
            );

            ViewBag.Projects = new SelectList(
                _context.Projects,
                "ProjectId",
                "ProjectName",
                task.ProjectId
            );

            return View(task);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskItem = _context.TaskItems.Find(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }
        [HttpPost]
        public IActionResult Delete(TaskItem taskItem)
        {
            _context.Remove(taskItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Search(string search)
        {
            var tasks = _context.TaskItems
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                tasks = tasks.Where(x =>
                    x.TaskName.Contains(search));
            }

            return View("Index", tasks.ToList());
        }
    }
}