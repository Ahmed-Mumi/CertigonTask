using System.Threading.Tasks;

namespace CertingTask.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        Task<bool> Complete();
    }
}
