using CertingTask.Models;
using System.Data.Entity;

namespace CertingTask.Interfaces
{
    public interface IEmployeeContext
    {
        IDbSet<Department> Departments { get; }
        IDbSet<Employee> Employees { get; }
        int SaveChanges();
    }
}
