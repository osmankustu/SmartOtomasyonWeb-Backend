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
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ProductCategory>> JoinedProductCategoryAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>()))
            {
                var result = from i in context.ProductsCategory.Include(i => i.Products) select i;
                
                return await result.ToListAsync();
            }
        }
    }
}
