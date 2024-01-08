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
    public class PageRepository : GenericRepository<Page>, IPagesRepository
    {
        public PageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Page> GetPageWithMetaAsync(Guid id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                var result = from p in context.Pages.Where(p => p.Id == id).Include(p => p.MetaTags) select p;

                return await result.FirstOrDefaultAsync();
            }
            
        }
    }
}
