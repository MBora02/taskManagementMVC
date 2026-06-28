using System.ComponentModel.DataAnnotations;

namespace taskManagementCrud.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentpersonelCount { get; set; }
    }
}

