using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class SocialLinks :BaseEntity
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid FooterId { get; set; }
        public String ClassName { get; set; }
    }
}
