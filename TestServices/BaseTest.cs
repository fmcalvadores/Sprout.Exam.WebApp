using Microsoft.Extensions.Logging;
using Moq;
using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Services;
using Sprout.Exam.DataAccess.Services.Interfaces;

namespace Sprout.Exam.Business.TestServices
{
    public class BaseTest
    {

        protected readonly IQueryService _queryService;
        protected readonly IEmployeeService _employeeService;

        public BaseTest()
        {
            var qLogger = Mock.Of<ILogger<QueryService>>();
            var eLogger = Mock.Of<ILogger<EmployeeService>>();
            var repo = Mock.Of<IRepository>();
            _queryService = new QueryService(qLogger, repo);
            _employeeService = new EmployeeService(eLogger, _queryService, repo);
            
        }

        
    }
}
