using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.About
{
    public class AboutView
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImgUri { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid PageId { get; set; }
    }
}
