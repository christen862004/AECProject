using AECProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AECProject.Controllers
{
    public class StudentController : Controller
    {
       //Student/Showall
       public IActionResult ShowAll()
        {
            //get model data
            StudentBL studentBL = new StudentBL();
            List<Student> StudentListModel= studentBL.GetAll();
            //send view
            return View("AllEmpView", StudentListModel);
            // go to view model =List<student
        }


       //Student/Details?id=1
       public IActionResult DEtails(int id)
        {
            StudentBL studentBL = new StudentBL();
            Student StdModel = studentBL.GetByID(id);
            return View("StdDetails",StdModel);//view StdDetails ,Model =Stietn
        }
    }
}
