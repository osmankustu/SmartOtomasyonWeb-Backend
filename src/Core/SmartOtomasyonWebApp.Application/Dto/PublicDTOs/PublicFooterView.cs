using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicFooterView
    {
        public String Name { get; set; }
        public String Adress { get; set; }
        public String Mail { get; set; }
        public Guid pageId { get; set; }


        public virtual ICollection<SocialLinks> SocialLinks { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
