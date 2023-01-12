using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Services.Interfaces;

namespace Sprout.Exam.Business.TestServices
{
    public class BaseTest
    {

        protected IRepository _repo;
        protected IQueryService _queryService;

        public BaseTest()
        {
            //var dbCOntext = new ApplicationDbContext(); 
        }
    }
}
