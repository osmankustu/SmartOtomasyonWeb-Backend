using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class DocumentCategory : BaseEntity
    {
        public String Name { get; set; }
        public Guid PageId { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        
    }
}
