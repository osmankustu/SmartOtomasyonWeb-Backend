using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.Referance;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.ReferanceQueries
{
    public class GetByIdReferanceQuery : IRequest<SuccessServiceResponse<ReferanceView>>
    {
        public Guid Id { get; set; }
        public class GetByIdReferanceQueryHandler : IRequestHandler<GetByIdReferanceQuery, SuccessServiceResponse<ReferanceView>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public GetByIdReferanceQueryHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<ReferanceView>> Handle(GetByIdReferanceQuery request, CancellationToken cancellationToken)
            {
                var referance = await _referanceRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<ReferanceView>(referance);
                return new SuccessServiceResponse<ReferanceView>(viewModel);
            }
        }
    }
}
