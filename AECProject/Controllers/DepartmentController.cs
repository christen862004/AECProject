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

        public IActionResult Details(int id)
        {
            Department department = context.Department.FirstOrDefault(d=>d.Id == id);
            return View("Details", department);//view Details ,Model =DEpartment
        }
    }
}
