using Microsoft.EntityFrameworkCore;
using SmartOtomasyonWebApp.Application.Aspects;
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
    public class FooterRepository : GenericRepository<Footer,ApplicationDbContext>, IFooterRepository
    {
      
        public async Task<List<Footer>> GetAllPublicAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from nc in context.Footer.Include(i => i.SocialLinks).Include(i=>i.PhoneNumbers) select nc;

                return await result.ToListAsync();
            }
        }
    }
}
