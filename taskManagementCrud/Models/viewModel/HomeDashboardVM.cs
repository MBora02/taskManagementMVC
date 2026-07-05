using System.Collections.Generic;

namespace taskManagementCrud.Models.viewModel
{
    public class HomeDashboardVM
    {
        public int TotalTasks { get; set; }
        public int TotalProjects { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        
        public List<TaskItem> Tasks { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public List<Department> Departments { get; set; } = new();
    }
}
