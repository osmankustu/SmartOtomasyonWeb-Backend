using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class MailBox : BaseEntity
    {
        public String NameSureName { get; set; }
        public String Email { get; set; }
        public String Message { get; set; }
        public String Subject { get; set; }
        public String phone { get; set; }
        public Boolean IsRead { get; set; }

    }
}
