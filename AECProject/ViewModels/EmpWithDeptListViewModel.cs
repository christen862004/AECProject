using System.ComponentModel.DataAnnotations.Schema;

namespace AECProject.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Salary { get; set; }
        public string Image { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }//EF

        //+
        public List<Department> DeptList { get; set; }
    }
}
