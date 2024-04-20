using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AECProject.Controllers
{
    //[HandelError]
    //[Authorize]//login
    public class FiltterController : Controller
    {
        
        public IActionResult CheckLogin()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Claim idClaim = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id= idClaim.Value;

                Claim AddClaim = User.Claims
                    .FirstOrDefault(c => c.Type == "Address");
                string address= AddClaim.Value;

                string name = User.Identity.Name;
                return Content("Wleomce "+name);
            }
            //name user login
            return Content("Welcome Guest");
        }



        //[AllowAnonymous]//Gust
        public IActionResult Index()
        {
            throw new Exception("Action throw exception from action");
            return View();
        }
        public IActionResult Index2()
        {
            throw new Exception("Action throw exception from action");
            return View();
        }
    }
}
