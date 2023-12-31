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
    public class MainSliderRepository : GenericRepository<MainSlider>, IMainSliderRepository
    {
        public MainSliderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
