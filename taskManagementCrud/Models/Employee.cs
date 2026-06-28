using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskManagementCrud.Models
{
    public class Employee
    {
        [Key]
        public int EmployeId { get; set; }

        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int EmployeeAge { get; set; }
        public string EmployeeGender { get; set; }
        public int EmployeePhone { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [ValidateNever]
        public virtual Department Department { get; set; }
    }
}
