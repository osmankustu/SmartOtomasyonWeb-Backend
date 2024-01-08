using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Dto.Referance;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.ReferanceQueries.GetAllReferance
{
    public class GetAllReferanceQuery : IRequest<ServiceResponse<List<ReferanceView>>>
    {
        public class GetAllReferanceQueryHandler : IRequestHandler<GetAllReferanceQuery,ServiceResponse<List<ReferanceView>>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public GetAllReferanceQueryHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<ReferanceView>>> Handle(GetAllReferanceQuery request, CancellationToken cancellationToken)
            {
                var referances = await _referanceRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<ReferanceView>>(referances);
                return new ServiceResponse<List<ReferanceView>>(viewModel,Messages.ReferanceListed);
            }
        }
    }
}
