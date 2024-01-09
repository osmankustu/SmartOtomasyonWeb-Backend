using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicProductCategoryView
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public string ImgUri { get; set; }
        public Guid PageId { get; set; }
        public virtual ICollection<Domain.Entities.Product> Products { get; set; }
    }
}
