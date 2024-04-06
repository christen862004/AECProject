using AECProject.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AECProject.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
        }
        [HttpGet]//link
        public IActionResult New()
        {
            ViewData["DeptList"] = context.Department.ToList();
            return View();//view with the same action name "New" ,Model = null
            //return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Employee empFromREquest)//,string name,int id)
        {
            if (empFromREquest.Name != null)
            {
                context.Employee.Add(empFromREquest);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.Department.ToList();
            return View("New",empFromREquest);//view name=New ,Model =Emp
        }

        public IActionResult Index()
        {
            //join depaty+ employee =>VIewModel
            //var result=
            //    context.Employee.Select(e => new { name = e.Name, id = e.Id, depName = e.Department.Name });
            //return View("Index", context.Employee.Include(e=>e.Department).ToList());//pagination
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
        public IActionResult SaveEdit(
            EmpWithDeptListViewModel empFromReq,
            Employee emp
            ,int id,string name,string address,int salary)
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
          //  Employee Model = new EmpWithDeptListViewModel();
            empFromReq.DeptList = context.Department.ToList();
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


        public IActionResult Details(int id ,string desc)
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
