using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Extensions
{
    public interface IIPHelper
    {
        public Task GetIpAddress(String Content ="Public Content");
    }
}
