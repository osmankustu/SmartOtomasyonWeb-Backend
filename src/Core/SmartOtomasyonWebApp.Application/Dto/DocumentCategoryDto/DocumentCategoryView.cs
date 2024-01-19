using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.DocumentCategoryDto
{
    public class DocumentCategoryView 
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid PageId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
