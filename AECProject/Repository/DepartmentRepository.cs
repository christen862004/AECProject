using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AECProject.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        //CRUD
        ITIContext context;
        public string Id { get; set; }
       
        public DepartmentRepository(ITIContext _context)//new object create
        {
            Id = Guid.NewGuid().ToString();
            context =_context;// new ITIContext();//Create or ask IOC
        }
        
        public List<Department> GetAll()//string? include=null)
        {
            return context.Department.ToList();
        }
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department delObj = GetById(id);
            context.Remove(delObj);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
