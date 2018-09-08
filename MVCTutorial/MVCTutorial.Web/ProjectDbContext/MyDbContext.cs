using MVCTutorial.Web.Models;
using System.Data.Entity;

namespace MVCTutorial.Web.ProjectDbContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("DefaultConnectionString")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}