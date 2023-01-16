using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Common.Results
{
    public class APIResult
    {

        public string Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string FieldName { get; set; }

        public APIResult()
        {
            Success = false;
            Message = "";
            FieldName = "";
            Id = "";


        }

        public class ApiOneResult<TEntity> : APIResult where TEntity : class, new()
        {
            public TEntity Data { get; set; }
        }

        public class ApiManyResult<TEntity> : APIResult where TEntity : class, new()
        {
            public IEnumerable<TEntity> Data { get; set; }
            public long TotalFilteredData { get; set; }
            public long TotalData { get; set; }
        }
    }
}
