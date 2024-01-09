using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.EndContentDto
{
    public class EndContentView
    {
        public Guid Id { get; set; }
        public String SiteName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid HomeId { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
