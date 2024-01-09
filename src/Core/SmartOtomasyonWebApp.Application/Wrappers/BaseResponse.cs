using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    public class BaseResponse<T> :Result,IDataResponse<T>
    {

        //public Guid Id { get; set; }
        //public bool Success { get; set; }
        //public String Message { get; set; }

        public BaseResponse(T data,bool success,String message):base(success,message)
        {
            Data = data;
        }
        public BaseResponse(T data,bool success):base(success)
        {
            Data = data;
        }

        public T Data { get; set; }

    }
}
