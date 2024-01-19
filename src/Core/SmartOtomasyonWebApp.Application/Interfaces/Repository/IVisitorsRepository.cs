using SmartOtomasyonWebApp.Application.Dto;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IVisitorsRepository : IGenericRepositoryAsync<Visitors>
    {
        public Task AddVisitorAsync(Visitors visitors);
        public Task<List<Visitors>> GetAllDateNowVisitorAsync();

        public Task<List<Visitors>> GetDailyVisitorAsync();

        public Task<List<Visitors>> GetLastLoginAttempts();
        public Task<List<Visitors>> GetLastVisits();
        public Task<List<YearlVisitorDto>> GetYearlyVisitors();
    }
}
