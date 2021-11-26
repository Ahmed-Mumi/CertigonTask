using CertingTask.Interfaces;
using CertingTask.Models;
using System.Data.Entity;

namespace CertingTask.Data
{
    public class FakeEmployeeContext : IEmployeeContext
    {
        public FakeEmployeeContext()
        {
            this.Departments = new FakeDepartmentSet();
            this.Employees = new FakeEmployeeSet();
        }

        public IDbSet<Department> Departments { get; private set; }

        public IDbSet<Employee> Employees { get; private set; }
        //public void SetModified(object entity)
        //{
        //    Entry(entity).State = EntityState.Modified;
        //}
        public int SaveChanges()
        {
            return 0;
        }
    }
}
