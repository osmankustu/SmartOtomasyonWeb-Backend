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
    public class WorkImageCategoryRepository : GenericRepository<WorkImageCategory, ApplicationDbContext>, IWorkImageCategoryRepository
    {
        public async Task<List<WorkImageCategory>> GetAllPublicAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from ic in context.WorkImageCategory select ic;
                return await result.ToListAsync();
            }
        }
    }
}
