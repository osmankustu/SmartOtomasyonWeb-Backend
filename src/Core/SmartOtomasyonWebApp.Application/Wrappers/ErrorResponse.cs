using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    public class ErrorResponse : Result
    {
        public ErrorResponse(string message) : base(false, message)
        {
            Message = message;
        }

        public ErrorResponse() : base(false)
        {

        }

        public string Message { get; set; }
    }
}
