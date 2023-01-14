using AutoMapper;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Common.Results;
using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Repository.Entities;
using Sprout.Exam.DataAccess.Services.Extensions;
using Sprout.Exam.DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services
{
    public class EmployeeService: BaseService, IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IQueryService _queryService;
        public EmployeeService(ILogger<EmployeeService> logger, IQueryService queryService, IRepository repo) : base(logger, repo, queryService)
        {
            _queryService = queryService;
            _mapper = this.GetMapper();
        }
        public async Task<Result> AddEmployee(CreateEmployeeDTO dto)
        {
            var response = new Result();
            try
            {

                // TODO : add validations
                var employeeCount = await _repo.GetCountAsync<Employee>();

                var employee = new Employee() {
                    Birthdate = dto.Birthdate,
                    EmployeeTypeId = dto.TypeId,
                    FullName = dto.FullName,
                    TIN = dto.Tin,
                    Salary = dto.Salary,
                    IsDeleted = false
                };
                
                _repo.Create(employee);
                await _repo.SaveAsync();

                response.Id = employee.Id.ToString();
                response.Success = true;
                response.Message = "The employee was added Successfully";

            }
            catch (Exception e)
            {
                _logger.LogError("Error calling AddEmployee: {0}", e.Message);
            }
            return response;
        }

        public float CalculateSalary(EmployeeDTO dto)
        {
            var netPay = 0;
            try
            {
                
            }
            catch (Exception e)
            {
                _logger.LogError("Error calling CalculateSalary: {0}", e.Message);
            }
            return netPay;
        }

        public async Task<Result> Deletemployee(int id)
        {
            var response = new Result();
            try
            {
                var employee = _repo.GetFirstAsync<Employee>(filter: e => e.Id == id).Result;
                if (employee == null)
                {
                   return response;
                }
                _repo.Delete(employee);
                await _repo.SaveAsync();

                response.Success = true;
                response.Message = "Employee successfully deleted.";

            }
            catch (Exception e)
            {
                _logger.LogError("Error calling Deletemployee: {0}", e.Message);
            }
            return response;
        }

        public async Task<EmployeeDTO> UpdateEmployee(EditEmployeeDTO dto)
        {
            var response = new EmployeeDTO();
            try
            {
                var employee = await _repo.GetFirstAsync<Employee>(filter: c => c.Id == dto.Id);
                
                if (employee == null)
                {
                    
                    return response;
                }

                employee.Birthdate = dto.Birthdate;
                employee.EmployeeTypeId = dto.TypeId;
                employee.FullName = dto.FullName;
                employee.IsDeleted = dto.IsDeleted;
                employee.TIN = dto.Tin;

                _repo.Update(employee);
                await _repo.SaveAsync();
                //response.Success = true;
                //response.Message = "Employee successfully edited";

                response = _mapper.Map<EmployeeDTO>(employee);

            }
            catch (Exception e)
            {
                _logger.LogError("Error calling UpdateEmployee: {0}", e.Message);
            }
            return response;

        }
    }
}
