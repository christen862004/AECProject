using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AECProject.Controllers
{
    [Authorize(Roles ="Admin")]//cookie ===>claim role=Admin
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager)
        {
            roleManager = RoleManager;
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleFromREq)
        {
            if(ModelState.IsValid)
            {
                //create role db
                IdentityRole role = new IdentityRole() { Name=roleFromREq.RoleNAme};
                IdentityResult result= await roleManager.CreateAsync(role);
                if ((result.Succeeded))
                {
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
