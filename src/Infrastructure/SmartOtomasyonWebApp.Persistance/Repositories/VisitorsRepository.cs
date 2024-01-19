using Microsoft.EntityFrameworkCore;
using SmartOtomasyonWebApp.Application.Aspects;
using SmartOtomasyonWebApp.Application.Dto;
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
    public class VisitorsRepository : GenericRepository<Visitors, ApplicationDbContext>, IVisitorsRepository
    {
        public async Task AddVisitorAsync(Visitors visitors)
        {
            using(var context = new ApplicationDbContext())
            {
                await context.Visitors.AddAsync(visitors);
                await context.SaveChangesAsync();
                
            }
        }

        public async Task<List<Visitors>> GetAllDateNowVisitorAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from visitors in context.Visitors.Where(v => v.CreateAt.Hour == DateTime.Now.Hour) select visitors;
                return await result.ToListAsync();
            }
            
        }

        [SecuredOperation("Admin")]
        public async Task<List<Visitors>> GetDailyVisitorAsync()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from visitors in context.Visitors.Where(v => v.CreateAt.Date == DateTime.Now.Date && v.OnContent == "Public Content") select visitors;
                return await result.ToListAsync();
            }
        }

        [SecuredOperation("Admin")]
        public async Task<List<Visitors>> GetLastLoginAttempts()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from v in context.Visitors.Where(v=>v.OnContent == "Admin Login").OrderByDescending(v=>v.CreateAt).Take(10) select v;
                return await result.ToListAsync();
                
            }
        }

        [SecuredOperation("Admin")]
        public async Task<List<Visitors>> GetLastVisits()
        {
            using (ApplicationDbContext context = new())
            {
                var result = from v in context.Visitors.Where(v => v.OnContent == "Public Content").OrderByDescending(v=>v.CreateAt).Take(5) select v;
                return await result.ToListAsync();
            }
        }

        [SecuredOperation("Admin")]
        public async Task<List<YearlVisitorDto>> GetYearlyVisitors()
        {
            using (ApplicationDbContext context = new())
            {
                List<YearlVisitorDto> visit = new List<YearlVisitorDto>();
                List<String> months = new List<String>() 
                { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
                int i = 0;
                while (true)
                {
                    if(i >= 12)
                    {
                        break;
                    }
                    YearlVisitorDto visitDto = new YearlVisitorDto();
                    Visitors visitors = new Visitors();
                    var result = from v in context.Visitors where v.CreateAt.Month == i + 1 && v.CreateAt.Year == DateTime.Now.Year && v.OnContent == "Public Content" select v;

                    visitDto.ay = months[i];
                    visitDto.count = result.Count();
                    visit.Add(visitDto);
                    i++;
                }

                return  visit.ToList();
            }
                

        }
    }
}
