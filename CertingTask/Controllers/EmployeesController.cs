using CertingTask.Dtos;
using CertingTask.Interfaces;
using CertingTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertingTask.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employeeReturn = await _employeeService.GetEmployees();
            return Ok(employeeReturn);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employeeReturn = await _employeeService.GetEmployee(id);
            if (employeeReturn == null)
                return NotFound("Employee does not exist.");
            return employeeReturn;
        }
        [HttpGet("{active:bool}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(bool active)
        {
            var employeesReturn = await _employeeService.GetInActiveEmployees(active);
            return Ok(employeesReturn);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(AddEmployeeDto addEmployeeDto)
        {
            if (await _employeeService.PostEmployee(addEmployeeDto))
                return NoContent();
            return BadRequest("Failed to add employee");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await _employeeService.GetEmployeeById(updateEmployeeDto.Id);
            if (employee == null)
                return NotFound("Employee does not exist.");
            if (await _employeeService.UpdateEmployee(updateEmployeeDto, employee))
                return NoContent();
            //if savechanges function is false we would return BadRequest("Failed to update employee.");
            return BadRequest("Failed to update employee");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound("Employee does not exist.");
            if (await _employeeService.DeleteEmployee(employee))
                return Ok();
            return BadRequest("Failed to delete employee");
        }
    }
}
