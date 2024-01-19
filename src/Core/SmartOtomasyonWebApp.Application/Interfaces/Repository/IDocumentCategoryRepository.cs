using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IDocumentCategoryRepository : IGenericRepositoryAsync<DocumentCategory>
    {
        public Task<List<DocumentCategory>> getAllPublicAsync();
    }
}
