using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    public class ServiceResponse<T> :BaseResponse<T>
    {

        public ServiceResponse(T data,String message):base(data,true,message)
        {

        }
        public ServiceResponse(T data):base(data,true)
        {

        }
        public ServiceResponse(String message):base(default,true)
        {

        }
        public ServiceResponse():base(default,true)
        {

        }

    }
}
