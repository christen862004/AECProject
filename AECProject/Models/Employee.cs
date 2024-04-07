using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AECProject.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        //[Required]
        [MinLength(length:3,ErrorMessage ="Name Must be greater than 2 char")]//search
        [MaxLength(25,ErrorMessage ="Name Must be les than 25 char")]
        [Unique]//(xyz =10)]//Server Side only 
        //[RegularExpression("[a-zA-Z]{3,}")]
        public string Name { get; set; }

        [RegularExpression("(Alex|Cairo|Menia)",ErrorMessage ="Address Must be one of (Alex ,Cairo ,Menia) City")]
        public string? Address { get; set; }

        //[Range(6000,25000)]
        [Remote(action:"CheckSalary"
            ,controller:"Employee",
            ErrorMessage ="Salary invalid",
            AdditionalFields = "JobTitle"
            )]//view client side validation JS
        public int Salary { get; set; }



        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]
        public string Image { get; set; }
        
        public string JobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name="DEpartment")]//ppt
        public int DepartmentId { get; set; }//EF

        public Department? Department { get; set; }//not Required
    }
}
