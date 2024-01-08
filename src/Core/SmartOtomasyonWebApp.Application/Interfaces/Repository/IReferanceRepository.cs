using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IReferanceRepository : IGenericRepositoryAsync<Referance>
    {
        public Task<List<Referance>> GetAllReferanceWithMeta();
    }
}
