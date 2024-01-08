﻿using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class About : BaseEntity
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImgUri { get; set; }
        public Guid PageId { get; set; }
    }
}
