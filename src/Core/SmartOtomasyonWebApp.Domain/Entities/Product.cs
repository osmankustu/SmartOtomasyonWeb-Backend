﻿using SmartOtomasyonWebApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Domain.Entities
{
    public class Product :BaseEntity
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public decimal value { get; set; }
    }
}
