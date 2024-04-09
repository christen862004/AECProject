namespace AECProject.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult DeptEmp()
        {
            List<Department> DeptList = context.Department.ToList();
            return View("DeptEmp", DeptList);
        }
       
        //DEpartment/GetEmpByDEpt?deptid=1 calling using ajax
        public IActionResult GetEmpByDEpt(int deptid)
        {
            List<Employee> empList= context.Employee.Where(e => e.DepartmentId == deptid).ToList();
            return Json(empList);
        }
    
        //test action partial
        //define action return part on page
        public IActionResult DeptPartial(int id)
        {
            Department dept= context.Department.FirstOrDefault(x => x.Id == id);
            //return PartialView("Details", dept);//dont call viewStart file 
            return PartialView("_DepartmentDEtailsPartial", dept);
        }


        //Department/index All Departe
        public IActionResult Index()
        {
           // context.Find()
            List<Department> departmentList=context.Department.ToList();
            return View("Index",departmentList);//View Index ,Model List<Department>
        }
      
        //CAn server any request type (GET |POST)
        public IActionResult Details(int id)
        {
            Department department = context.Department.FirstOrDefault(d=>d.Id == id);
            return View("Details", department);//view Details ,Model =DEpartment
        }

        public IActionResult ConfirmDelete(int id)
        {
            Department dept = context.Department.FirstOrDefault(d => d.Id == id);
            return View(dept);
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
