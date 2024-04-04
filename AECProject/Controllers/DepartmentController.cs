namespace AECProject.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        
        //Department/index All Departe
        public IActionResult Index()
        {
            List<Department> departmentList=context.Department.ToList();
            return View("Index",departmentList);//View Index ,Model List<Department>
        }
        //CAn server any request type (GET |POST)
        public IActionResult Details(int id)
        {
            Department department = context.Department.FirstOrDefault(d=>d.Id == id);
            return View("Details", department);//view Details ,Model =DEpartment
        }
        //press anchor tag
        
        [HttpGet]
        public IActionResult New()
        {
            return View("New");
        }

        //Press Submit button
        //DEpartment/SaveNEw?Name=SD&ManagerName=Ahmed
        [HttpPost]//action attribute
        public IActionResult SaveNew(Department DeptFromReq) {
            //if(Request.Method== "POST") { 
            if(DeptFromReq.Name != null)
            {
                context.Add(DeptFromReq);
                context.SaveChanges();
                return RedirectToAction("Index","Department");
            }
          
            return View("New", DeptFromReq);//View ="NEw" ,Model =DEptartment
        }
    }
}
