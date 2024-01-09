using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.CenterContentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetCenterContentQueries
{
    public class GetByIdCenterContentQuery : IRequest<IDataResponse<CenterContentView>>
    {
        public Guid Id { get; set; }
        public class GetByIdCenterContentHandler : IRequestHandler<GetByIdCenterContentQuery, IDataResponse<CenterContentView>>
        {
            ICenterContentRepository _centerContentRepository;
            private readonly IMapper _mapper;
            public GetByIdCenterContentHandler(ICenterContentRepository centerContentRepository, IMapper mapper)
            {
                _centerContentRepository = centerContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<CenterContentView>> Handle(GetByIdCenterContentQuery request, CancellationToken cancellationToken)
            {
                var content = await _centerContentRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<CenterContentView>(content);
                return new SuccessServiceResponse<CenterContentView>(viewModel);
            }
        }
    }
}
