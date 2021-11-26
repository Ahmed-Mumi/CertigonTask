using CertingTask.Data.Repositories;
using CertingTask.Interfaces;
using CertingTask.Models;
using System.Threading.Tasks;

namespace CertingTask.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private FakeEmployeeContext _fakeEmployeeContext;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            _fakeEmployeeContext = new FakeEmployeeContext()
            {
                Employees =
                {
                    new Employee{Id=1,FirstName="Chandler",LastName="Bing",IsActive=true,DepartmentId=1},
                    new Employee{Id=2,FirstName="Ross",LastName="Geller",IsActive=false,DepartmentId=2},
                    new Employee{Id=3,FirstName="Joey",LastName="Tribbiani",IsActive=true,DepartmentId=3},
                    new Employee{Id=4,FirstName="Monica",LastName="Geller",IsActive=false,DepartmentId=1},
                    new Employee{Id=5,FirstName="Phoebe",LastName="Buffay",IsActive=true,DepartmentId=2},
                    new Employee{Id=6,FirstName="Rachel",LastName="Green",IsActive=false,DepartmentId=3}
                }
            };
        }
        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_context, _fakeEmployeeContext);
        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
