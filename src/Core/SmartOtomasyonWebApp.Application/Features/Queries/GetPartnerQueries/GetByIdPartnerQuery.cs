using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PartnerDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetPartnerQueries
{
    public class GetByIdPartnerQuery : IRequest<IDataResponse<PartnerView>>
    {
        public Guid Id { get; set; }
        public class GetByIdPartnerQueryHandler : IRequestHandler<GetByIdPartnerQuery, IDataResponse<PartnerView>>
        {
            IPartnerRepository _partnerRepository;
            private readonly IMapper _mapper;
            public GetByIdPartnerQueryHandler(IPartnerRepository partnerRepository, IMapper mapper)
            {
                _partnerRepository = partnerRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<PartnerView>> Handle(GetByIdPartnerQuery request, CancellationToken cancellationToken)
            {
                var partners = await _partnerRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<PartnerView>(partners);
                return new SuccessServiceResponse<PartnerView>(viewModel);
            }
        }
    }
}
