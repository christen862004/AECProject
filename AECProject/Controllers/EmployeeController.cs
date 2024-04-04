using AECProject.ViewModels;


namespace AECProject.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
        }
        public IActionResult Index()
        {
            return View("Index", context.Employee.ToList());//pagination
        }

        //press Link
        public IActionResult Edit(int id)
        {
            Employee empModel= context.Employee.FirstOrDefault(e => e.Id == id);
            List<Department> departmentList= context.Department.ToList();

            //View need to Employee obj + List<DEpartment> (Mapping to VM)
            EmpWithDeptListViewModel EmpViewModel= new EmpWithDeptListViewModel();
            EmpViewModel.Id = empModel.Id;
            EmpViewModel.Name = empModel.Name;
            EmpViewModel.Image = empModel.Image;
            EmpViewModel.Address = empModel.Address;
            EmpViewModel.Salary = empModel.Salary;
            EmpViewModel.JobTitle = empModel.JobTitle;
            EmpViewModel.DepartmentId = empModel.DepartmentId;
            EmpViewModel.DeptList= departmentList;


            return View("Edit",EmpViewModel);//load old info
        }

        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel empFromReq)
        {
            if(empFromReq.Name!=null && empFromReq.Salary > 6000)
            {
                //get data from viewmodel ==>model
                Employee empFromDB = context.Employee.FirstOrDefault(e => e.Id == empFromReq.Id);
                empFromDB.Name = empFromReq.Name;
                empFromDB.Address = empFromReq.Address;
                empFromDB.Salary = empFromReq.Salary;
                empFromDB.Image = empFromReq.Image;
                empFromDB.JobTitle = empFromReq.JobTitle;
                empFromDB.DepartmentId = empFromReq.DepartmentId;
                //context.Update(empFromReq);//id Added (0) | id found Modified
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", empFromReq);
        }













        public IActionResult DetailsWithVm(int id)
        {
            //Get Data From Db
            Employee EmpModel=context.Employee.FirstOrDefault(e=>e.Id==id);
            List<string> branches = new List<string>();
            branches.Add("Smart");
            branches.Add("New Capital");
            branches.Add("Alex");
            //Mapping Model ==>viewModel
            var EmpViewmModel = new EmployeeNAmeWithClrDateMsgBranchesViewModel();
          //package auto mapper
            EmpViewmModel.EmpID = EmpModel.Id;
            EmpViewmModel.EmpNAme = EmpModel.Name;
            EmpViewmModel.Branches = branches;
            EmpViewmModel.Msg = "Hello";
            EmpViewmModel.Color ="red";

            EmpViewmModel.Temp =30;


            //return view ==>vm
            return View("DetailsWithVm", EmpViewmModel);
        }


        public IActionResult Details(int id)
        {
            /*Extra info from action View*/
            string Msg = "Welcome From Action";
            ViewData["Message"] = Msg;
            
            List<string> branches = new List<string>();
            branches.Add("Smart");
            branches.Add("New Capital");
            branches.Add("Alex");
            ViewData["brch"] = branches;

            ViewData["Temp"] = 30;
                       
            ViewData["clr"] = "red";
            
            ViewBag.clr = "blue"; 

            ViewData["DateTime"]= DateTime.Now;

            ViewBag.age = 30; //set 

            Employee employee=context.Employee.FirstOrDefault(e=>e.Id==id);
            return View("Details",employee);
            
        }
    }
}
