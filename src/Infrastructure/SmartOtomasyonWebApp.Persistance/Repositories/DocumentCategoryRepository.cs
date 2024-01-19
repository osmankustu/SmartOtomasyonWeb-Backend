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
    public class DocumentCategoryRepository : GenericRepository<DocumentCategory, ApplicationDbContext>, IDocumentCategoryRepository
    {
        public async Task<List<DocumentCategory>> getAllPublicAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from i in context.DocumentCategory select i;
                return await result.ToListAsync();
            }
        }
    }
}
