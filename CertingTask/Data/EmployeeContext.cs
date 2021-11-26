using CertingTask.Interfaces;
using CertingTask.Models;
using System.Data.Entity;

namespace CertingTask.Data
{
    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<Employee> Employees { get; set; }

    }
}
