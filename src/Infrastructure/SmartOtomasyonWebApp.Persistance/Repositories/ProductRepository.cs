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
    public class ProductRepository : GenericRepository<Product,ApplicationDbContext> ,IProductRepository
    {
      

        public async Task<List<Product>> GetAllPublicAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from p in context.Products select p;
                return await result.ToListAsync();
            }
        }

        public async Task<List<Product>> GetByCategoryIdAsync(Guid id)
        {
            using (ApplicationDbContext context = new())
            {
                var result = from p in context.Products.Where(p=>p.ProductCategoryId==id) select p;
                return await result.ToListAsync();
            }
        }

        public async Task<Product> GetByIdPublicAsync(Guid id)
        {
            using (ApplicationDbContext context = new())
            {
                var result = from p in context.Products.Where(p=>p.Id == id) select p;
                return await result.FirstOrDefaultAsync();
            }
        }
    }
}
