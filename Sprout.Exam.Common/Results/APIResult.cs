using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Common.Results
{
    public class APIResult
    {

        public string Message { get; set; }

        public bool Success { get; set; }

        public APIResult()
        {
            Message = "";
            Success = false;


        }
    }
}
