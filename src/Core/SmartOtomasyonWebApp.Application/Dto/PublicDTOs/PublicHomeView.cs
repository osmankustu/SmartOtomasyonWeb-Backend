using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicHomeView
    {
        public String Name { get; set; }
        public Guid PageId { get; set; }

        public virtual ICollection<MainSlider> sliders { get; set; }
        public virtual ICollection<CenterContent> centerContents { get; set; }
        public virtual ICollection<Partner> Partners { get; set; }
        public virtual ICollection<EndContent> EndContents { get; set; }
        public virtual ICollection<WorkImages> workImages { get; set; }
    }
}
