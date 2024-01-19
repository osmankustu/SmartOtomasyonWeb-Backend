using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.DashboardDto
{
    public class Dashboard
    {
        public int count { get; set; }
        public ICollection<Visitors> LastLogin { get; set; }
        public ICollection<Visitors> LastVisit { get; set; }
        public ICollection<YearlVisitorDto> YearlVisit { get; set; }

    }
}
