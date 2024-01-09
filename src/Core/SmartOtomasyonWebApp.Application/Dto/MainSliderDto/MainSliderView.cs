using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.MainSliderDto
{
    public class MainSliderView
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid HomeId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
