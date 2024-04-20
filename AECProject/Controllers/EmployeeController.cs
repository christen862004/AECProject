using AECProject.Repository;
using AECProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AECProject.Controllers
{
    
    public class EmployeeController : Controller
    {
        //  ITIContext context = new ITIContext();
        IEmployeeRepository EmployeeRepository;
        IDepartmentRepository DepartmentRepository;

        public EmployeeController
            (IEmployeeRepository empRepo, IDepartmentRepository DeptREpo)//DI dont create ask CTOR
        {
            EmployeeRepository = empRepo;
            DepartmentRepository = DeptREpo;
        }
        //call using ajax
        public IActionResult CheckSalary(int Salary,string JobTitle)
            //check [] another property come from request
        {
            //uniue email 
            
            if (Salary < 25000 && Salary > 6000 && JobTitle=="M")//range
                return Json(true);
            else if(Salary<10000 && Salary >6000 && JobTitle=="S")
                return Json(true);
            else
                return Json(false);
        }

        //layer Service
        [HttpGet]//link
        public IActionResult New()
        {
            /*id,name,nameDept*/
            List<EmpWithDeptNameViewModel> emp =EmployeeRepository.GetAll()
                .Select(e => new EmpWithDeptNameViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    DeptName = e.Department.Name
                }).ToList();



            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View();//view with the same action name "New" ,Model = null
            //return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Employee empFromREquest)//,string name,int id)
        {
           // if (empFromREquest.Name.len != null)
            if(ModelState.IsValid==true)
            {
                try
                {
                    EmployeeRepository.Insert(empFromREquest);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch (Exception ex)
                {
                    ModelState.AddModelError("DepartmentId", "Please Select DEpartemt");
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);//annoums key 
                }
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New",empFromREquest);//view name=New ,Model =Emp ,Model State
        }


        [Authorize]//check cookie ==REdirect to login
        public IActionResult Index()
        {
            //join depaty+ employee =>VIewModel
            //var result=
            //    context.Employee.Select(e => new { name = e.Name, id = e.Id, depName = e.Department.Name });
            //return View("Index", context.Employee.Include(e=>e.Department).ToList());//pagination
            return View("Index",EmployeeRepository.GetAll());//pagination
        }

        //press Link
        public IActionResult Edit(int id)
        {
            Employee empModel=EmployeeRepository.GetById(id);
            List<Department> departmentList = DepartmentRepository.GetAll();

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
                Employee empFromDB = EmployeeRepository.GetById(empFromReq.Id);
                empFromDB.Name = empFromReq.Name;
                empFromDB.Address = empFromReq.Address;
                empFromDB.Salary = empFromReq.Salary;
                empFromDB.Image = empFromReq.Image;
                empFromDB.JobTitle = empFromReq.JobTitle;
                empFromDB.DepartmentId = empFromReq.DepartmentId;
                //context.Update(empFromReq);//id Added (0) | id found Modified
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            //  Employee Model = new EmpWithDeptListViewModel();
            empFromReq.DeptList = DepartmentRepository.GetAll();
            return View("Edit", empFromReq);
        }













        public IActionResult DetailsWithVm(int id)
        {
            //Get Data From Db
            Employee EmpModel = EmployeeRepository.GetById(id);
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

            Employee employee = EmployeeRepository.GetById(id);
            return View("Details",employee);
            
        }
    }
}
