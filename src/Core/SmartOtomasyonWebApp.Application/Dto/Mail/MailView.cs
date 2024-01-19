using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.Mail
{
    public class MailView
    {
        public Guid Id { get; set; }
        public String NameSureName { get; set; }
        public String Email { get; set; }
        public String Message { get; set; }
        public Boolean IsRead { get; set; }
        public String Subject { get; set; }
        public String phone { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
