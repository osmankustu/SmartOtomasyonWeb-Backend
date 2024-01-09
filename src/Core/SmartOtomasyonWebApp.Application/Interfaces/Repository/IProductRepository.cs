using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepositoryAsync<Product>
    {
        public Task<List<Product>> GetAllPublicAsync();
        public Task<Product> GetByIdPublicAsync(Guid id);
        public Task<List<Product>> GetByCategoryIdAsync(Guid id);



    }
}
