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
    public class UserRepository : GenericRepository<User,ApplicationDbContext>, IUserRepository
    {
       

        public async Task<User> GetByMail(string mail)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from u in context.User.Where(u=>u.Email == mail) select u;
                return await result.SingleOrDefaultAsync();
            }
        }

        public async Task<List<OperationClaim>> getClaims(User user)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var result = from oc in context.OperationClaim
                             join uop in context.UserOperationClaim
                             on oc.Id equals uop.OperationClaimId
                             where uop.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = oc.Id,
                                 Name = oc.Name,
                                 CreateAt = oc.CreateAt
                             };
                return  await result.ToListAsync();
            }
        }
    }
}
