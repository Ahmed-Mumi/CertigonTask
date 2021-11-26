using AutoMapper;
using CertingTask.Dtos;
using CertingTask.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertingTask.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{departmentId}/employees/{active?}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByDepartmentId(int departmentId, bool active = true)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeesByDepartmentIdAsync(departmentId, active);
            var employeeReturn = _mapper.Map<IEnumerable<EmployeeDto>>(employee);
            return Ok(employeeReturn);
        }
    }
}
