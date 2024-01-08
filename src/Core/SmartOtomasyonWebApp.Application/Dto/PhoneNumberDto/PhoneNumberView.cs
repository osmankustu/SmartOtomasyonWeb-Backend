using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PhoneNumberDto
{
    public class PhoneNumberView  
    {
        public Guid Id{ get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public Guid FooterId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
