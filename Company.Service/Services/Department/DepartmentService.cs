using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public DepartmentDto GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department == null)
            {
                return null;
            }

            DepartmentDto departmentDto= _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappedDepartments;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAT = DateTime.Now,
            //};
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Update(DepartmentDto department)
        {
            var dept =_unitOfWork.DepartmentRepository.GetById(department.Id);
            if (dept.Name != department.Name)
            {
               if (GetAll().Any(x=>x.Name==department.Name))
                    throw new Exception("Department name already exists");
            }
            dept.Name = department.Name;
            dept.Code = department.Code;

            //_unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();


        }

        public void Delete(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }

    }
}
