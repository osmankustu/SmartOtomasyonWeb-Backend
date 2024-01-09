using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class EndContent : BaseEntity
    {
        public String SiteName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid HomeId { get; set; }
    }
}
