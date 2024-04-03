using AECProject.ViewModels;


namespace AECProject.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
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
