using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiValidationErrorResponse:ApiResponse
    {
        internal string[] Errors;

        public ApiValidationErrorResponse():base(400){

        }
        public IEnumerable<string> MyProperty { get; set; }
        
    }
}