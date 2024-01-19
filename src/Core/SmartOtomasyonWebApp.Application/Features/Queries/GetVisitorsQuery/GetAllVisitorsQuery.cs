using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto;
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
    public class GetAllVisitorsQuery : IRequest<IDataResponse<List<VisitorsDto>>>
    {
        public class GetAllVisitorsQueryHandler : IRequestHandler<GetAllVisitorsQuery,IDataResponse<List<VisitorsDto>>>
        {
            IVisitorsRepository _visitors;
            private readonly IMapper _mapper;
            public GetAllVisitorsQueryHandler(IVisitorsRepository visitors,IMapper mapper)
            {
                _visitors = visitors;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<VisitorsDto>>> Handle(GetAllVisitorsQuery request, CancellationToken cancellationToken)
            {
                var visitors = await _visitors.GetAllAsync();
                var viewModel = _mapper.Map<List<VisitorsDto>>(visitors);
                return new SuccessServiceResponse<List<VisitorsDto>>(viewModel);
            }
        }
    }
}
