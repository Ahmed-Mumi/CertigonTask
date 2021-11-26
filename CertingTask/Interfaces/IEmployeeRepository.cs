using CertingTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertingTask.Interfaces
{
    public interface IEmployeeRepository
    {
        void UpdateEmployee(Employee employee);
        void AddEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> GetInActiveEmployeeAsync(bool active);
        Task<Employee> GetEmployeeAsync(int id);
        void DeleteEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId, bool active);
    }
}
