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
    public class UpperNavbarRepository : GenericRepository<UpperNavbar>, IUpperNavbarRepository
    {
        public UpperNavbarRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
