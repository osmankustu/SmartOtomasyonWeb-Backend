using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Meta : BaseEntity
    {
        public String Name { get; set; }
        public String Content { get; set; }
        public Guid PageId { get; set; }

        public virtual Page page { get; set; }
    }
}
