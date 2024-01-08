using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.WorkImageCategoryDto
{
    public class WorkImageCategoryView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PageId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
