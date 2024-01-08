using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Footer :BaseEntity
    {
        public String Name { get; set; }
        public String Adress { get; set; }
        public String Mail { get; set; }
        public Guid PageId { get; set; }

        public virtual ICollection<SocialLinks> SocialLinks { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
