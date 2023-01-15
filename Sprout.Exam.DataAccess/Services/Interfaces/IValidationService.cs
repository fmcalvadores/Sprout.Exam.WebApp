using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Results;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services.Interfaces
{
    public interface IValidationService
    {
        Task<Result> ValidateEmployee(CreateEmployeeDTO dto);
    }
}
