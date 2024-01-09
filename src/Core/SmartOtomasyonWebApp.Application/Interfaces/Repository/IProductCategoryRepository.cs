﻿using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IProductCategoryRepository :IGenericRepositoryAsync<ProductCategory>
    {
        public Task<List<ProductCategory>> GetAllPublicAsync();
    }
}
