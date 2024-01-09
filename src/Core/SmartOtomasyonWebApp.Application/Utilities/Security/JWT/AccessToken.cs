using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Utilities.Security.JWT
{
    public class AccessToken
    {

        public  string name { get; set; }
        public string surename { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
