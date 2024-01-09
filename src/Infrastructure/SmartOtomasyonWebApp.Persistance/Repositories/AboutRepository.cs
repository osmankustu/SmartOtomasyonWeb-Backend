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
    
    public class AboutRepository : GenericRepository<About,ApplicationDbContext> ,IAboutRepository
    {
       
        
        public async Task<List<About>> GetAllAboutPublicAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from a in context.About select a;

                return await result.ToListAsync();
            }
        }
    }
}
