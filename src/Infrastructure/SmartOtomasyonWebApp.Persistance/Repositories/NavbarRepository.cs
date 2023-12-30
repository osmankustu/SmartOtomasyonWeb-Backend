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
    public class NavbarRepository : GenericRepository<Navbar>,INavbarRepository
    {
        public NavbarRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        public  async Task<List<Navbar>> AsyncJoinedNavbarCategories()
        {
            using (ApplicationDbContext context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
            {
                var result = from nc in context.Navbar.Include(i=>i.NavbarCategory) select nc;
                             
                return await result.ToListAsync();
            }
        }
    }
}
