using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PartnerDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetPartnerQueries
{
    public class GetAllPartnerQuery : IRequest<IDataResponse<List<PartnerView>>>
    {
        public class GetAllPartnerQueryHandler : IRequestHandler<GetAllPartnerQuery,IDataResponse<List<PartnerView>>>
        {
            IPartnerRepository _partnerRepository;
            private readonly IMapper _mapper;
            public GetAllPartnerQueryHandler(IPartnerRepository partnerRepository, IMapper mapper)
            {
                _partnerRepository = partnerRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PartnerView>>> Handle(GetAllPartnerQuery request, CancellationToken cancellationToken)
            {
                var partners = await _partnerRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<PartnerView>>(partners);
                return new SuccessServiceResponse<List<PartnerView>>(viewModel);
            }
        }
    }
}
