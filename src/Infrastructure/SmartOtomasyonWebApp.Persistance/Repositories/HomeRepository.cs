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
    public class HomeRepository : GenericRepository<Home, ApplicationDbContext>, IHomeRepository
    {
        public async Task<List<Home>> GetAllPublicAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from h in context.Home
                             .Include(p => p.sliders)
                             .Include(p => p.centerContents)
                             .Include(p => p.Partners)
                             .Include(p => p.EndContents)
                             .Include(p=> p.workImages) select h;
                return await result.ToListAsync();
            }
        }
    }
}
