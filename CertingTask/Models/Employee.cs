namespace CertingTask.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
