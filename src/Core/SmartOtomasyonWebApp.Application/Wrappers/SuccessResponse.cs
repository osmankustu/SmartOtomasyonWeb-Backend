using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    internal class SuccessResponse :Result
    {
        public SuccessResponse(string message) : base(true)
        {
            Message = message;
        }

        public SuccessResponse() : base(true)
        {

        }
        public string Message { get; }

    }
}
