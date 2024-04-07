using System.ComponentModel.DataAnnotations;

namespace AECProject.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        public int xyz { get; set; }


        //build in attribute
        ITIContext context = new ITIContext();

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)//value property (Value) ,obj(validationcontext)
        {
            string name = value.ToString();
            Employee empFromReq =(Employee) validationContext.ObjectInstance;
            
            //search with the same name and the same department
            Employee? EmpFromDB = 
                context.Employee
                .FirstOrDefault(e => e.Name.ToLower() == name.ToLower() && e.DepartmentId ==empFromReq.DepartmentId);    
           
            if(EmpFromDB == null) {
                //unique valid value
                return ValidationResult.Success;
            }
            //already found not unique
            return new ValidationResult("Name Already Found :(");
        }
    }
}
