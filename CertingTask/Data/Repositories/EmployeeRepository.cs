using CertingTask.Interfaces;
using CertingTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertingTask.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly FakeEmployeeContext _fakeEmployeeContext;

        public EmployeeRepository(DataContext context, FakeEmployeeContext fakeEmployeeContext)
        {
            _context = context;
            _fakeEmployeeContext = fakeEmployeeContext;
        }
        public void AddEmployee(Employee employee)
        {
            _fakeEmployeeContext.Employees.Add(employee);
            //_context.Employees.Add(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            _fakeEmployeeContext.Employees.Remove(employee);
            //_context.Employees.Remove(employee);
        }
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return _fakeEmployeeContext.Employees.Find(id);
            //return await _context.Employees.FindAsync(id);
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return _fakeEmployeeContext.Employees.ToList();
            //return await _context.Employees.ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetInActiveEmployeeAsync(bool active)
        {
            var employees = _fakeEmployeeContext.Employees.Where(x => x.IsActive == active).ToList();
            //var employees = await _context.Employees.Where(x => x.IsActive == active).ToListAsync();
            return employees;
        }
        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId, bool active)
        {
            return _fakeEmployeeContext.Employees
                .Where(x => x.DepartmentId == departmentId && x.IsActive == active)
                .ToList();
            //return await _context.Employees
            //    .Where(x => x.DepartmentId == departmentId && x.IsActive == active)
            //    .ToListAsync();
        }
    }
}
