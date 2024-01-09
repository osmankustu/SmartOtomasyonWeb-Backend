using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Home : BaseEntity
    {
        public String Name { get; set; }
        public Guid PageId { get; set; }

        public ICollection<MainSlider> sliders { get; set; }
        public ICollection<CenterContent> centerContents { get; set; }
        public ICollection<Partner> Partners { get; set; }
        public ICollection<EndContent> EndContents { get; set; }
        public ICollection<WorkImages> workImages { get; set; }


    }
}
