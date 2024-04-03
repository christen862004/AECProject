using Microsoft.EntityFrameworkCore;

namespace AECProject.Models
{
    //Deal wirth db
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public ITIContext():base()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //DbCotnext Option 4
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITI_AEC44;Integrated Security=True;Encrypt=False");//
        }

        //fill some data in table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department()
            {
                Id=1,Name="AEC",ManagerName="Ahmed"
            });
            modelBuilder.Entity<Department>().HasData(new Department()
            {
                Id = 2,
                Name = "PWD",
                ManagerName = "Sadaat"
            });
            //Insert data in table
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id=1,Name="Ahmed",Address="Alex",Salary=20000,JobTitle="Backend Developer",DepartmentId=1,Image="m.png"});
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 2, Name = "Gaser", Address = "Alex", Salary = 25000, JobTitle = "FS Developer", DepartmentId = 2, Image = "m.png" });
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 3, Name = "Safaa", Address = "Cairo", Salary = 25000, JobTitle = "Frontend Developer", DepartmentId = 1, Image = "2.jpg" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
