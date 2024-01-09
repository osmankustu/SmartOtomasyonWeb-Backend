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
    public class WorkImagesRepository : GenericRepository<WorkImages,ApplicationDbContext>, IWorkImagesRepository
    {
       

        public async Task<List<WorkImages>> GetByCategoryIdAsync(Guid id)
        {
            using (ApplicationDbContext context = new())
            {
                var result = from nc in context.WorkImages.Where(i=>i.ImageCategoryId == id) select nc;

                return await result.ToListAsync();
            }

        }

        public async Task<List<WorkImages>> GetAllPublicAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from nc in context.WorkImages select nc;

                return await result.ToListAsync();

            }
        }

        [SecuredOperation("Admin")]
        public async Task<List<WorkImages>> JoinedGetAllAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from nc in context.WorkImages.Include(i => i.ImageCategory) select nc;

                return await result.ToListAsync();
            }
           
        }
    }
}
