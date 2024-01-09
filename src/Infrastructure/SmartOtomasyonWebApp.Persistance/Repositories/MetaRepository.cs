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
    public class MetaRepository : GenericRepository<Meta,ApplicationDbContext>, IMetaRepository
    {
      

        public async Task<List<Meta>> GetAllWithPageAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from m in context.Meta.Include(m => m.page) select m;
                return await result.ToListAsync();
            }
        }
    }
}
