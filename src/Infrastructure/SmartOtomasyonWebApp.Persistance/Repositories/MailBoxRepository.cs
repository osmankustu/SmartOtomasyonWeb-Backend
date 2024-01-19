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
    public class MailBoxRepository : GenericRepository<MailBox, ApplicationDbContext>, IMailBoxRepository
    {
        public async Task PublicAddAsync(MailBox mailbox)
        {
            using (ApplicationDbContext context = new())
            {
                await context.MailBox.AddAsync(mailbox);
               await context.SaveChangesAsync();

            }
        }
    }
}
