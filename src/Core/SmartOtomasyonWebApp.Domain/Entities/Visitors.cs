using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Visitors : BaseEntity
    {
        public String IpAddress { get; set; }
        public String CountryName { get; set; }
        public String CountryCode { get; set; }
        public String RegionName  { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public String Continent  { get; set; }
        public String OnContent { get; set; }
        public Boolean IsProxy { get; set; }
    }
}
