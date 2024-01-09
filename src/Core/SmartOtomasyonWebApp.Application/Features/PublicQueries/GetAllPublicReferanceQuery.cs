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
    public class GetAllPublicReferanceQuery : IRequest<SuccessServiceResponse<List<PublicReferanceView>>>
    {
        public class GetAllPublicReferanceQueryHandler : IRequestHandler<GetAllPublicReferanceQuery,SuccessServiceResponse<List<PublicReferanceView>>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public GetAllPublicReferanceQueryHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<PublicReferanceView>>> Handle(GetAllPublicReferanceQuery request, CancellationToken cancellationToken)
            {
                var referances = await _referanceRepository.GetAllReferanceWithMeta();
                var viewModel = _mapper.Map<List<PublicReferanceView>>(referances);
                return new SuccessServiceResponse<List<PublicReferanceView>>(viewModel);
            }
        }
    }
}
