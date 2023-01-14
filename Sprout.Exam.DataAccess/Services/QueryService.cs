using AutoMapper;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Results;
using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Repository.Entities;
using Sprout.Exam.DataAccess.Services.Extensions;
using Sprout.Exam.DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services
{
    public class QueryService : BaseService, IQueryService
    {
        private readonly IMapper _mapper;

        public QueryService(ILogger<QueryService> logger, IRepository repo) : base(logger, repo)
        {   
            _mapper = this.GetMapper();
        }
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var response = new List<EmployeeDTO>();
            try
            {
                var employeeList = await _repo.GetAsync<Employee>();
                
               response = _mapper.Map<List<EmployeeDTO>>(employeeList);
            }
            catch (Exception e) 
            {
                _logger.LogError("Error calling GetAllEmployees: {0}", e.Message);
            }
            return response;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var response = new EmployeeDTO();
            try
            {
                var employee = await _repo.GetFirstAsync<Employee>(
                    filter: d => d.Id == id
                    );
                response = _mapper.Map<EmployeeDTO>(employee);
            }
            catch (Exception e) 
            {
                _logger.LogError("Error calling GetEmployeeById: {0}", e.Message);
            }
            return response;
        }
    }
}
