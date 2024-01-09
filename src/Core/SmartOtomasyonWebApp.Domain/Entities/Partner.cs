using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Partner : BaseEntity
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid HomeId { get; set; }
    }
}
