using System.ComponentModel.DataAnnotations;

namespace AECProject.Models
{
    public class Department
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }// Not Allow NULL
        //public bool Isdelete { get; set; } = false;//Soft Delet "Update"

        public List<Employee> Employees { get; set; }
    }
}
