using Microsoft.Extensions.Logging;
using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Services
{
    public class BaseService
    {
        protected readonly ILogger _logger;
        protected readonly IRepository _repo;
        private readonly IQueryService _queryService;

        public BaseService(ILogger logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public BaseService(ILogger logger)
        {
            _logger = logger;
            
        }

        public BaseService(ILogger logger, IRepository repo, IQueryService queryService)
        {
            _logger = logger;
            _repo = repo;
            _queryService = queryService;
        }
    }

}
