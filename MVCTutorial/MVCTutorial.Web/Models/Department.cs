using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTutorial.Web.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string DepartmentHead { get; set; }

        // nagivation property
        public ICollection<Employee> Employees { get; set; }
    }
}