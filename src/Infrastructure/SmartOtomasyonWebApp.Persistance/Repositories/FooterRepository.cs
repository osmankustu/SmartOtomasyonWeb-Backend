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
    public class FooterRepository : GenericRepository<Footer>, IFooterRepository
    {
        public FooterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Footer>> JoinedGetAllAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                var result = from nc in context.Footer.Include(i => i.SocialLinks).Include(i=>i.PhoneNumbers) select nc;

                return await result.ToListAsync();
            }
        }
    }
}
