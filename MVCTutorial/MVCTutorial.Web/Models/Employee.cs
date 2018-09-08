using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTutorial.Web.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }

        // navigation properties
        public int DepartmentId { get; set; }
    }
}