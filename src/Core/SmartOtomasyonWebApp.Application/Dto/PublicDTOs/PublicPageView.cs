using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicPageView
    {
        public String Name { get; set; }
        public ICollection<Meta> MetaTags{ get; set; }
    }
}
