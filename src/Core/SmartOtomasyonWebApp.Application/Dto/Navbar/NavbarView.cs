﻿using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.NavbarCategory
{
    public class NavbarView
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Domain.Entities.NavbarCategory> NavbarCategory { get; set; }
    }
}
