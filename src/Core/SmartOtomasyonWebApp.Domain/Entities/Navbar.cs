using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Navbar :BaseEntity
    {
        
        public String Name { get; set; }

        public virtual ICollection<NavbarCategory> NavbarCategory { get; set; }
    }
}
