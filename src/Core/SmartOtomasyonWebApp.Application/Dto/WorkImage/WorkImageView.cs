using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.WorkImage
{
    public class WorkImageView
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid ImageCategoryId { get; set; }
        public System.Nullable<Guid> HomeId { get; set; }
        public WorkImageCategory ImageCategory { get; set; }

    }
}
