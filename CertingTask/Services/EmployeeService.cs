using AutoMapper;
using CertingTask.Dtos;
using CertingTask.Interfaces;
using CertingTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertingTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetEmployeesAsync();
            var employeesReturn = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesReturn;
        }
        public async Task<EmployeeDto> GetEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetEmployeeAsync(id);
            var employeeReturn = _mapper.Map<EmployeeDto>(employee);
            return employeeReturn;
        }
        public async Task<IEnumerable<EmployeeDto>> GetInActiveEmployees(bool active)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetInActiveEmployeeAsync(active);
            var employeesReturn = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesReturn;
        }

        public async Task<bool> PostEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeAdd = _mapper.Map<Employee>(addEmployeeDto);
            _unitOfWork.EmployeeRepository.AddEmployee(employeeAdd);
            return true;
            //return await _unitOfWork.Complete();
        }

        public async Task<bool> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeUpdate = await _unitOfWork.EmployeeRepository.GetEmployeeAsync(updateEmployeeDto.Id);
            if (employeeUpdate == null) return false;
            _mapper.Map(updateEmployeeDto, employeeUpdate);
            _unitOfWork.EmployeeRepository.UpdateEmployee(employeeUpdate);
            return true;
            //return await _unitOfWork.Complete();
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employeeDelete = await _unitOfWork.EmployeeRepository.GetEmployeeAsync(id);
            if (employeeDelete == null) return false;
            _unitOfWork.EmployeeRepository.DeleteEmployee(employeeDelete);
            return true;
            //return await _unitOfWork.Complete();
        }
    }
}
