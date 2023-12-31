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
    public class FooterRepository : GenericRepository<Footer>, IFooterRepository
    {
        public FooterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
