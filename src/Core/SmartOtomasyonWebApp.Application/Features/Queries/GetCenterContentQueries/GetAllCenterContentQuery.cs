using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.CenterContentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetCenterContentQueries
{
    public class GetAllCenterContentQuery : IRequest<IDataResponse<List<CenterContentView>>>
    {
        public class GetAllCenterContentHandler : IRequestHandler<GetAllCenterContentQuery, IDataResponse<List<CenterContentView>>>
        {
            ICenterContentRepository _centerContentRepository;
            private readonly IMapper _mapper;
            public GetAllCenterContentHandler(ICenterContentRepository centerContentRepository, IMapper mapper)
            {
                _centerContentRepository = centerContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<CenterContentView>>> Handle(GetAllCenterContentQuery request, CancellationToken cancellationToken)
            {
                var content = await _centerContentRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<CenterContentView>>(content);
                return new SuccessServiceResponse<List<CenterContentView>>(viewModel);
            }
        }
    }
}
