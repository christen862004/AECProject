using AECProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AECProject.Controllers
{
    //must be end with Controller
    //must be public 
    //must be inherit from contoller
    
    public class HomeController : Controller
    {
        //must be public
        //must  not be Static
        //cant be overload

        //url "Name ofClass/Name Method (action)
        //Home/showmsG
        //public string ShowMsg()
        //{
        //    return "Hello";
        //}
        public ContentResult ShowMsg()
        {
            //Logic
            //declare obj
            ContentResult result = new ContentResult();
            //set data
            result.Content = "Hello From Action";
            //return 
            return result;
        }
        //action view
        //endpoint :/home/showView
        public ViewResult ShowView()
        {
            //logic
            //declare
            return View("View1");
        }
        //private ViewResult View(string viewname)
        //{
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = viewname;
        //    //return
        //    return result;
        //}
        //action id=
        //home/ShowMix?ID=1&name=ahmed   // (QS) parameter name = value &
        public IActionResult ShowMix(int id,string name)
        {
            if (id == 13)
            {
                //declare obj
                return Content("Hello FRom Action");
                //NotFoundResult result = new NotFoundResult();
                //return result;
                //return NotFound()
            }
            else
            {
                //logic
                return View("View1");
            }
        }










        //action can return :
        // 1- Content  ==> ContentResult   ==>Content
        // 2- View     ==> ViewResult      ==>View
        // 3- Json     ==> JsonREsult      ==>Json
        // 4- NotFound ==> NotFoundRsult   ==>NotFound()
        // 5- File     ==> FileResult
        // 6- .....












        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration =0, 
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
