using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Result> AddEmployee(CreateEmployeeDTO dto);

        Task<EmployeeDTO> UpdateEmployee(EditEmployeeDTO dto);

        Task<Result> Deletemployee(int id);

        double CalculateSalaryForRegular(float salary, float absentDays);

        double CalculateSalaryForContractual(float salary, float workedDays);

        int GetDates(int year, int month);
    }
}
