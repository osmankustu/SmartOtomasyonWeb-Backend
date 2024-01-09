using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    public class ErrorServiceResponse<T> : BaseResponse<T>
    {
        public ErrorServiceResponse(T data, string message) : base(data, false, message)
        {

        }
        public ErrorServiceResponse(T data) : base(data, false)
        {

        }
        public ErrorServiceResponse(string message) : base(default, false, message)
        {

        }
        public ErrorServiceResponse() : base(default, false)
        {

        }
    }
}
