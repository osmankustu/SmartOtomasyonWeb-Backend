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
    public class ProductRepository : GenericRepository<Product> ,IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        public Task<List<Product>> JoinedProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
