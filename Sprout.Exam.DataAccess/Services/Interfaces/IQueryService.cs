using Sprout.Exam.Business.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services.Interfaces
{
    public interface IQueryService
    {
        Task<List<EmployeeDTO>> GetAllEmployees();

        Task<EmployeeDTO> GetEmployeeById(int id);

        Task<EmployeeDTO> GetEmployeeByFullName(string FullName);

        Task<EmployeeDTO> SearchForTIN(string TIN);
    }
}
