using AECProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AECProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptREpo;

        public ServiceController
            (IDepartmentRepository deptREpo)//,IDepartmentRepository deptREpo2)
        {
            this.deptREpo = deptREpo;
        }

        //service/index
        public IActionResult Index()//[FromServices]IDepartmentRepository deptREpo) 
        {
            ViewBag.Id = deptREpo.Id;
            return View();
        }
    }
}
