using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } =  Guid.NewGuid();
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
