namespace AECProject.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        void Insert(Employee obj);
        void Update(Employee obj);
        void Delete(int id);
        List<Employee> GetByDeptId(int deptId);
        void Save();
    }
}
