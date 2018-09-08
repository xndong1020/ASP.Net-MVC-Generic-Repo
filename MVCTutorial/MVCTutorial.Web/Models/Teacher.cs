using System.Collections.Generic;

namespace MVCTutorial.Web.Models
{
    public class Teacher 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Age { get; set; }

        // Navigation Properties
        public ICollection<Student> Students { get; set; }
    }
}