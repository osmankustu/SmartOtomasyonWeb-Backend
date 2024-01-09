using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    public class SuccessServiceResponse<T> :BaseResponse<T> 
    {

        public SuccessServiceResponse(T data,String message):base(data,true,message)
        {

        }
        public SuccessServiceResponse(T data):base(data,true)
        {

        }
        public SuccessServiceResponse(String message):base(default,true)
        {

        }
        public SuccessServiceResponse():base(default,true)
        {

        }

    }
}
