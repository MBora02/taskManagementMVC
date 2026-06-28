using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskManagementCrud.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectUserCount { get; set; }
        public int ProjectTotalWeek { get; set; }

        [ValidateNever]
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [ValidateNever]
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
