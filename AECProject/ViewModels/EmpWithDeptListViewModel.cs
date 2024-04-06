using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AECProject.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Password)] //Editor Type
        [Display(Name="Employee Name")]  //label
        public string Name { get; set; }
        
        public string? Address { get; set; }
        public int Salary { get; set; }
        public string Image { get; set; }
        public string JobTitle { get; set; }
      
        [Display(Name="-- Department --")]//display property name 
        public int DepartmentId { get; set; }//EF

        //+
        public List<Department> DeptList { get; set; }
    }
}
