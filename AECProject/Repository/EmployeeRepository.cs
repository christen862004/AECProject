namespace AECProject.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _Context)
        {
            context = _Context;//new ITIContext();
        }
        public List<Employee> GetAll()//string? include=null)
        {
            return context.Employee.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee delObj = GetById(id);
            context.Remove(delObj);
        }
        public List<Employee> GetByDeptId(int deptId)
        {
            return context.Employee.Where(e => e.DepartmentId == deptId).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
