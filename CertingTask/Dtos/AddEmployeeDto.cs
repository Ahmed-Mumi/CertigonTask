using System.ComponentModel.DataAnnotations;

namespace CertingTask.Dtos
{
    public class AddEmployeeDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentId { get; set; }
    }
}
