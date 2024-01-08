using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class UpperNavbar :BaseEntity
    {
        public String Email { get; set; }

        //public virtual ICollection<SocialLinks>  SocialLinks { get; set; }
        //public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
