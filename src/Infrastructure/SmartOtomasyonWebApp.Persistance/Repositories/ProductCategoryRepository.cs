using Microsoft.EntityFrameworkCore;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Domain.Entities;
using SmartOtomasyonWebApp.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Persistance.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory,ApplicationDbContext>, IProductCategoryRepository
    {
      

        public async Task<List<ProductCategory>> GetAllPublicAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from i in context.ProductsCategory.Include(i => i.Products) select i;
                
                return await result.ToListAsync();
            }
        }
    }
}
