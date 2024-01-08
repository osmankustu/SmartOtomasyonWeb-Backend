using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.ProductCategory
{
    public class ProductCategoryView 
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public string ImgUri { get; set; }
        public Guid PageId { get; set; }
        public ICollection<Domain.Entities.Product> Products { get; set; }
    }
}
