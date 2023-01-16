using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Results;
using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Services.Interfaces;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services
{
    public class ValidationService : BaseService, IValidationService
    {
        private readonly IQueryService _queryService;

        public ValidationService(ILogger<ValidationService> logger, IQueryService queryService, IRepository repo) : base(logger, repo, queryService)
        {
            _queryService = queryService;
        }

        public async Task<Result> ValidateEmployee(CreateEmployeeDTO dto)
        {
            var result = new Result();
            try
            {

                if (string.IsNullOrEmpty(dto.FullName)) {
                    return new Result()
                    {
                        FieldName = "fullName",
                        Message = "Employee is Required",
                    };
                }

                var validateFullName = await _queryService.GetEmployeeByFullName(dto.FullName);
                if (validateFullName.FullName != null) {
                    return new Result()
                    {
                        FieldName = "fullName",
                        Message = "Employee already exist",
                    };
                }

                var validateTIN = await _queryService.SearchForTIN(dto.Tin);
                if (validateTIN.Tin != null)
                {
                    return new Result()
                    {
                        FieldName = "tin",
                        Message = "TIN Id already exist",
                    };
                }

                if (!DateTime.TryParse(dto.Birthdate.ToLongDateString(), out DateTime tempDoB))
                {
                    return new Result()
                    {
                        FieldName = "birthdate",
                        Message = "Invalid date format",
                    };
                }

                if (!double.TryParse(dto.Salary.ToString(), NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), out double money))
                {
                    return new Result()
                    {
                        FieldName = "salary",
                        Message = "Invalid amount format",
                    };
                }

                result.Success = true;

            }
            catch (Exception e)
            {
                _logger.LogError("Error calling ValidateEmployee: {0}", e.Message);
            }

            return result;
        }
    }
}
