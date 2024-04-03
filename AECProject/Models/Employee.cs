using System.ComponentModel.DataAnnotations.Schema;

namespace AECProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Salary { get; set; }
        public string Image { get; set; }
        public string JobTitle { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }//EF

        public Department Department { get; set; }
    }
}
