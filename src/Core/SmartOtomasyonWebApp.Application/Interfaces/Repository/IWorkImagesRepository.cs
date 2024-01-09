using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IWorkImagesRepository : IGenericRepositoryAsync<WorkImages>
    {
        public  Task<List<WorkImages>> JoinedGetAllAsync();
        public Task<List<WorkImages>> GetByCategoryIdAsync(Guid id);
        public Task<List<WorkImages>> GetAllPublicAsync();
    }
}
