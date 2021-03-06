using CertingTask.Dtos;
using CertingTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertingTask.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployee(int id);
        Task<IEnumerable<EmployeeDto>> GetInActiveEmployees(bool active);
        Task<bool> PostEmployee(AddEmployeeDto addEmployeeDto);
        Task<bool> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, Employee employee);
        Task<bool> DeleteEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);

    }
}
