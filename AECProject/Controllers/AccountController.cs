using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AECProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> signInManager)
        {
            userManager = UserManager;
            this.signInManager = signInManager;
        }
        //creaet user
        ////Account/register :GET
        [HttpGet] //open link
        public IActionResult register()
        {
            return View("register");//empty view
        }
        //Account/register   :post
        //Account/register/1 :Post
        [HttpPost]//press submit 
        public async Task<IActionResult> register(RegisterUserViewModel userFromRequest)
        {
            if(ModelState.IsValid)
            {
                //mapping
                ApplicationUser user = new ApplicationUser();
                user.UserName = userFromRequest.UserName;
                user.PasswordHash = userFromRequest.Password;
                user.Address= userFromRequest.Address;

                //add user db ==> UserManager
                IdentityResult result=
                    await userManager.CreateAsync(user,userFromRequest.Password);

                if (result.Succeeded == true)
                {
                    //add role Admin
                    IdentityResult roleResut= await userManager.AddToRoleAsync(user, "Admin");
                    //create cookie //id,username,role
                    await signInManager.SignInAsync(user, false);//session Cookie
                    return RedirectToAction("Index", "Employee");
                }
                //fail to save db
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            //data wrong
            return View("register",userFromRequest);//empty view


        }
        //login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //check
                 ApplicationUser userFRomDB=
                    await userManager.FindByNameAsync(userFromReq.UserName);
                if (userFRomDB != null)
                {
                    bool found=await userManager.CheckPasswordAsync(userFRomDB, userFromReq.Passwrod);
                    if (found==true)
                    {
                        //create cookie(id,name,role,address)
                        //await signInManager.SignInAsync(userFRomDB, userFromReq.RememberMe);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", userFRomDB.Address));

                        await signInManager.SignInWithClaimsAsync(userFRomDB, userFromReq.RememberMe, claims);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login");
        }




        //logout
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
             
            return RedirectToAction("Login");
        }
    }
}
