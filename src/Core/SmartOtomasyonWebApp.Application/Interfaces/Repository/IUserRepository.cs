using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        public Task<User> GetByMail(string mail);
        public Task<List<OperationClaim>> getClaims(User user);
      
    }
}
