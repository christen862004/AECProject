
namespace AECProject.Repository
{
    public class DEptREpositoryFromMemory : IDepartmentRepository
    {
        List<Department> deptList;
        public DEptREpositoryFromMemory()
        {
            deptList = new List<Department>();
            deptList.Add(new Department() { Id=1,Name="dept"});
            deptList.Add(new Department() { Id = 2, Name = "dept2" });
        }

        public string Id { get ; set; }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return deptList;
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Department obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Department obj)
        {
            throw new NotImplementedException();
        }
    }
}
