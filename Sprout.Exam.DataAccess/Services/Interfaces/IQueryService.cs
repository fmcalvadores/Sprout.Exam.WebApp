using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services.Interfaces
{
    public interface IQueryService
    {
        Task<List<EmployeeDto>> GetAllEmployees();

        Task<EmployeeDto> GetEmployeeById(int id);
    }
}
