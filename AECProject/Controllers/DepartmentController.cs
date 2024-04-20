using AECProject.Repository;
using System.Runtime.InteropServices;

namespace AECProject.Controllers
{
    //open etend open modifictaion DIP
    //Hign level (conroller) depend low level (repository)
    
    public class DepartmentController : Controller
    {
        //low level
        IDepartmentRepository DepartmentRepository;//null
        IEmployeeRepository EmployeeRepository;//null
        //DI (constructor)
        //Controller FActory
        public DepartmentController
            (IDepartmentRepository deptREpo,IEmployeeRepository EmpRepo)//ask (Inject)
        {
            DepartmentRepository = deptREpo;
            EmployeeRepository = EmpRepo;
        }
        //ITIContext context = new ITIContext();
        public IActionResult DeptEmp()
        {
            List<Department> DeptList = DepartmentRepository.GetAll();
            return View("DeptEmp", DeptList);
        }
       
        //DEpartment/GetEmpByDEpt?deptid=1 calling using ajax
        public IActionResult GetEmpByDEpt(int deptid)
        {
            List<Employee> empList= EmployeeRepository.GetByDeptId(deptid);
              
            return Json(empList);
        }
    
        //test action partial
        //define action return part on page
        public IActionResult DeptPartial(int id)
        {
            Department dept=DepartmentRepository.GetById(id);
            //return PartialView("Details", dept);//dont call viewStart file 
            return PartialView("_DepartmentDEtailsPartial", dept);
        }


        //Department/index All Departe
        public IActionResult Index()
        {
           // context.Find()
            List<Department> departmentList=DepartmentRepository.GetAll();
            return View("Index",departmentList);//View Index ,Model List<Department>
        }
      
        //CAn server any request type (GET |POST)
        public IActionResult Details(int id)
        {
            Department department =DepartmentRepository.GetById(id);
            return View("Details", department);//view Details ,Model =DEpartment
        }

        public IActionResult ConfirmDelete(int id)
        {
            Department dept = DepartmentRepository.GetById(id);
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
                DepartmentRepository.Insert(DeptFromReq);
                DepartmentRepository.Save();
                return RedirectToAction("Index","Department");
            }
          
            return View("New", DeptFromReq);//View ="NEw" ,Model =DEptartment
        }
    }
}
