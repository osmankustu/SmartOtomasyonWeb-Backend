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
    public class ReferanceRepository : GenericRepository<Referance,ApplicationDbContext>, IReferanceRepository
    {
       

        public async Task<List<Referance>> GetAllReferanceWithMeta()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from r in context.Referance select r;
                return await result.ToListAsync();
            }
        }
    }
}
