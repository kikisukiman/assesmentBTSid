using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssesmentWebApi.Models
{
    public class ApiResult
    {
        public int result { set; get; }
        public string message { set; get; }

        public ApiResult(int result, string message)
        {
            this.result = result;
            this.message = message;
        }
    }
}