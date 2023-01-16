using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Microsoft.Extensions.Logging;
using Sprout.Exam.DataAccess.Services.Interfaces;
using Sprout.Exam.Common.Results;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IQueryService _queryService;
        private readonly IEmployeeService _employeeService;
        private readonly IValidationService _validationService;

        public EmployeesController(ILogger<EmployeesController> logger,IQueryService queryService, IEmployeeService employeeService, IValidationService validationService)
        {
            _logger = logger;
            _queryService = queryService;
            _employeeService = employeeService;
            _validationService = validationService;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<EmployeeDTO> result = new();
            try {

                result = await Task.FromResult(await _queryService.GetAllEmployees());
            }
            catch(Exception e) 
            {
                _logger.LogError("Error Saving the GetAllEmployees: {0} - {1}", e.Message, e.InnerException);
            }
            
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var result = await Task.FromResult(await _queryService.GetEmployeeById(id));
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDTO input)
        {

            
            var employee = await _employeeService.UpdateEmployee(input);

            if (employee == null) return NotFound();
            return Ok(employee);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost, Produces("application/json")]
        public async Task<IActionResult> Post(CreateEmployeeDTO input)
        {

            var validateFullName = await _validationService.ValidateEmployee(input);
            if (!validateFullName.Success) return  BadRequest(validateFullName); 
            
            var result = await _employeeService.AddEmployee(input);
            return Ok(result);

        }

        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.Deletemployee(id);
            if (result == null) return NotFound();
            return Ok(id);
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate/{absentDays}/{workedDays}"), Produces("application/json")]
        public async Task<IActionResult> Calculate(int id, float absentDays, float workedDays)
        {

            var result = await Task.FromResult(await _queryService.GetEmployeeById(id));
            if (result == null) return NotFound();
            var type = (EmployeeType) result.TypeId;
            return type switch
            {
                EmployeeType.Regular =>
                    //create computation for regular.
                    Ok(_employeeService.CalculateSalaryForRegular(result.Salary, absentDays)),
                EmployeeType.Contractual =>
                    //create computation for contractual.
                    Ok(_employeeService.CalculateSalaryForContractual(result.Salary, workedDays)),
                _ => NotFound("Employee Type not found")
            };

        }

    }
}
