using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.Footer
{
    public class FooterView
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Adress { get; set; }
        public String Mail { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid PageId { get; set; }

        public virtual ICollection<SocialLinks> SocialLinks { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
