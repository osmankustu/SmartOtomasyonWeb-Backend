using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicGetByIdProductView
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String ImgUri { get; set; }
        public String Description { get; set; }
        public String UserManualUri { get; set; }
        public String TechDocumentUri { get; set; }
    }
}
