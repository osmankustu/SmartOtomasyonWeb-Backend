using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicReferanceQuery : IRequest<ServiceResponse<List<PublicReferanceView>>>
    {
        public class GetAllPublicReferanceQueryHandler : IRequestHandler<GetAllPublicReferanceQuery,ServiceResponse<List<PublicReferanceView>>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public GetAllPublicReferanceQueryHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<PublicReferanceView>>> Handle(GetAllPublicReferanceQuery request, CancellationToken cancellationToken)
            {
                var referances = await _referanceRepository.GetAllReferanceWithMeta();
                var viewModel = _mapper.Map<List<PublicReferanceView>>(referances);
                return new ServiceResponse<List<PublicReferanceView>>(viewModel);
            }
        }
    }
}
