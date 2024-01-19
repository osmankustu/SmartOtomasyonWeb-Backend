using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto
{
    public class VisitorsDto
    {
        public Guid Id { get; set; }
        public String ipAddress { get; set; }
        public String countryName { get; set; }
        public String countryCode { get; set; }
        public String regionName { get; set; }
        public String continent { get; set; }
        public String OnContent { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public Boolean isProxy { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
