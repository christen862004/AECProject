using Microsoft.AspNetCore.Mvc;

namespace AECProject.Controllers
{
    public class StateController : Controller
    {
        public IActionResult setsession()
        {
            //logic
            HttpContext.Session.SetString("Name", "ITI");
            HttpContext.Session.SetInt32("Age", 12);
            //logic
            return Content("Session Data Saved");
        }
        //any controller
        public IActionResult getsession()
        {
            //logic
            string n= HttpContext.Session.GetString("Name");
            int? age =  HttpContext.Session.GetInt32("Age");
            return Content($"Get Data FRom Session {n} \t {age}");
        }
    }
}
