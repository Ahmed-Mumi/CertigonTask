using AutoMapper;
using CertingTask.Dtos;
using CertingTask.Models;

namespace CertingTask.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
