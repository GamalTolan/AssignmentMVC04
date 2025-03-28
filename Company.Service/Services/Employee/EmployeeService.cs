using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Name = employeeDto.Name,
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    Email = employeeDto.Email,
            //    Phone = employeeDto.Phone,
            //    Salary = employeeDto.Salary,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //};
            employeeDto.ImageUrl=DocumentSettings.UploadFile(employeeDto.Image,"images");
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Name = employeeDto.Name,
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    Email = employeeDto.Email,
            //    Phone = employeeDto.Phone,
            //    Salary = employeeDto.Salary,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //};
            var employee = _mapper.Map<Employee>(employeeDto);

            
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        { 
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Address = x.Address,
            //    Age = x.Age,
            //    Email = x.Email,
            //    Phone = x.Phone,
            //    Salary = x.Salary,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee == null)
            {
                return null;
            }
            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    DepartmentId = employee.DepartmentId,
            //    Name = employee.Name,
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    Id = employee.Id,
            //    Email = employee.Email,
            //    Phone = employee.Phone,
            //    Salary = employee.Salary,
            //    HiringDate = employee.HiringDate,
            //    ImageUrl = employee.ImageUrl,
            //    CreateAT = employee.CreateAT,
            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public IEnumerable<EmployeeDto>  GetEmployeeByName(string name)

        {
             var employee= _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employee.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    Address = x.Address,
            //    Age = x.Age,
            //    Email = x.Email,
            //    Phone = x.Phone,
            //    Salary = x.Salary,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employee);
            return mappedEmployees;
        } 

        public void Update(EmployeeDto employee)
        {
           // _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }


    }
}
