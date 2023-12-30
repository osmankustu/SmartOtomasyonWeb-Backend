﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers
{
    public class ServiceResponse<T> :BaseResponse
    {
        public T Data { get; set; }

        public ServiceResponse(T data)
        {
            Data = data;
        }
    }
}
