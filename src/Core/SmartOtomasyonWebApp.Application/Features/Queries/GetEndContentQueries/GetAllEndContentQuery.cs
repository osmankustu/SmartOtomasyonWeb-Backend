using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.EndContentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetEndContentQueries
{
    public class GetAllEndContentQuery : IRequest<IDataResponse<List<EndContentView>>>
    {
        public class GetAllEndContentQueryHandler : IRequestHandler<GetAllEndContentQuery, IDataResponse<List<EndContentView>>>
        {
            IEndContentRepository _endContentRepository;
            private readonly IMapper _mapper;
            public GetAllEndContentQueryHandler(IEndContentRepository endContentRepository, IMapper mapper)
            {
                _endContentRepository = endContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<EndContentView>>> Handle(GetAllEndContentQuery request, CancellationToken cancellationToken)
            {
                var content = await _endContentRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<EndContentView>>(content);
                return new SuccessServiceResponse<List<EndContentView>>(viewModel);
            }
        }
    }
}
