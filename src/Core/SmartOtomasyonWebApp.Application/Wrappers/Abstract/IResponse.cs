using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers.Abstract
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
