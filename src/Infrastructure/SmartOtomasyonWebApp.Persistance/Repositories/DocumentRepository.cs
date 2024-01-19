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
    public class DocumentRepository : GenericRepository<Document, ApplicationDbContext>, IDocumentRepository
    {
        public async Task<List<Document>> getByCategoryIdAsync(Guid id)
        {
            using (ApplicationDbContext context = new())
            {
                var result = from d in context.Document.Where(d => d.DocumentCategoryId == id) select d;
                return await result.ToListAsync();
            }
        }

        public async Task<List<Document>> getPublicAsync()
        {
            using (ApplicationDbContext context =new ())
            {
                var result = from i in context.Document select i;
                return await result.ToListAsync();
            }
        }
    }
}
