using System;
using System.Collections.Generic;

namespace Sprout.Exam.Common.Results
{
    public class Result
    {
        public string Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        //public ErrorCode ErrorCode { get; set; }

        public Result()
        {
            Success = false;
            Message = "";
            //ErrorCode = ErrorCode.DEFAULT;
            Id = "";
        }
    }

    public class OneResult<TEntity> : Result where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
    }

    public class ManyResult<TEntity> : Result where TEntity : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }
        public long TotalFilteredEntities { get; set; }
        public long TotalEntities { get; set; }
    }
}

