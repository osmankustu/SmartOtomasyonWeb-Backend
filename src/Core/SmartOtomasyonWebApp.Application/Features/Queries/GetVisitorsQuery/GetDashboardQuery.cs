using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DashboardDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetVisitorsQuery
{
    public class GetDashboardQuery : IRequest<IDataResponse<Dashboard>>
    {
        public class GetDashboardQueryHandler: IRequestHandler<GetDashboardQuery,IDataResponse<Dashboard>>
        {
            IVisitorsRepository _visitors;
            public GetDashboardQueryHandler(IVisitorsRepository visitors)
            {
                _visitors = visitors;
            }

            public async Task<IDataResponse<Dashboard>> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.count =  _visitors.GetDailyVisitorAsync().Result.Count();
                dashboard.LastLogin = await _visitors.GetLastLoginAttempts();
                dashboard.YearlVisit = await _visitors.GetYearlyVisitors();
                dashboard.LastVisit = await _visitors.GetLastVisits();
                dashboard.LastVisit.Reverse();
                dashboard.LastLogin.Reverse();

                return new SuccessServiceResponse<Dashboard>(dashboard);
            }
        }


    }
}
