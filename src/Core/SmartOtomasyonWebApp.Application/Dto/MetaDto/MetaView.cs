using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.MetaDto
{
    public class MetaView 
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Content { get; set; }
        public Guid PageId { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Page page{ get; set; }
    }
}
