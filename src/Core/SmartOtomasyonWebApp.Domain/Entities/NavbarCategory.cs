using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class NavbarCategory :BaseEntity
    {
        public String Name { get; set; }
        public Guid NavbarId { get; set; }
        //public Navbar Navbar { get; set; }
    }
}
