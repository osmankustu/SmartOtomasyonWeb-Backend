using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicAboutView
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImgUri { get; set; }
        public Guid pageId { get; set; }
    }
}
