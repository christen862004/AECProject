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


        public IActionResult SetCookie()
        {
            //logic
            //obj =send=>Client Cookie Browser "response"
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Name","AEC");//session cookie

            HttpContext.Response.Cookies.Append("Age", "12",cookieOptions); //Presistent cookie 'Expiration'
            return Content("Cookie Saved");
        }
        public IActionResult getCookie()
        {
            //logic
            string? name= HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"name={name}\t age={age}");
        }
    }
}
