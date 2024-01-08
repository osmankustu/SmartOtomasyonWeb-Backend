using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public String Name { get; set; }
        public Guid PageId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
