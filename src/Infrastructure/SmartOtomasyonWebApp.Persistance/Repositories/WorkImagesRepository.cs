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
    public class WorkImagesRepository : GenericRepository<WorkImages>, IWorkImagesRepository
    {
        public WorkImagesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<WorkImages>> GetByCategoryId(Guid id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                var result = from nc in context.WorkImages.Where(i=>i.ImageCategoryId == id) select nc;

                return await result.ToListAsync();
            }

        }

        public async Task<List<WorkImages>> JoinedGetAllAsync()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                var result = from nc in context.WorkImages.Include(i => i.ImageCategory) select nc;

                return await result.ToListAsync();
            }
           
        }
    }
}
