﻿using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class WorkImages : BaseEntity
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid ImageCategoryId { get; set; }
        
        public System.Nullable<Guid> HomeId { get; set; }
        public WorkImageCategory ImageCategory { get; set; }
    }
}
