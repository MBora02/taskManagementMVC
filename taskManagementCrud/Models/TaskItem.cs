using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskManagementCrud.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        [ValidateNever]
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [ValidateNever]
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
