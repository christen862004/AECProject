using Microsoft.AspNetCore.Mvc;

namespace AECProject.Controllers
{
    public class RouteController : Controller
    {
        //Route/MEthod1
        //s/salam/10/red
        //s/salam/10
        //public IActionResult Method1(int age,string name ,string color)
        //{
        //    return Content("Method1");
        //}
        //route attribute
        [Route("M1/{name?}")]//remove default reout for this action
        public IActionResult MEthod1(string name)
        {
            return Content("Method1");
        }
        public IActionResult MEthod2()
        {
            return Content("Method2");
        }
    }
}
