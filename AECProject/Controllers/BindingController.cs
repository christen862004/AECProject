using Microsoft.AspNetCore.Mvc;

namespace AECProject.Controllers
{
    public class BindingController : Controller
    {
        //Binding Primitive Datatype Route?QS
        //URL:/Binding/TestPrimitive?id=1&name=asd
        //URL:/Binding/TestPrimitive/11?name=ahmed
        //http://localhost:28534/binding/TestPrimitive?name[1]=alaa&id=1&name[0]=Ahemd
        
        public IActionResult TestPrimitive(int id ,string[] name)
        {
            return Content($"{name} - {id}");
        }
        
        //Bind Collection
        //URL :/Binding/TestDic?Phones[Ahmed]=123&Phones[Sara]=456&name=AlaaPhones
        public IActionResult TestDic(Dictionary<string,string> Phones ,string name)
        {
            return Content("Ok");
        }

        //Custom Class
        //URL :/Binding/TestObj?id=1&name=sd&managername=ahmed
        // http://localhost:28534/binding/Testobj/13?name=sd&managername=Ahemd&Employees[0].name=alaaaaaaa
        public IActionResult TestObj(Department dept,string stdname)
        //(int Id,string Name,string? ManagerName,List<Employee> Employees)
        {
            return Content("ok");
        }

    }
}
