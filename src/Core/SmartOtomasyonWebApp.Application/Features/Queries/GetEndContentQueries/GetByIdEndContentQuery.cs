using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.EndContentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetEndContentQueries
{
    public class GetByIdEndContentQuery : IRequest<IDataResponse<EndContentView>>
    {
        public Guid Id { get; set; }
        public class GetByIdEndContentQueryHandler : IRequestHandler<GetByIdEndContentQuery, IDataResponse<EndContentView>>
        {
            IEndContentRepository _endContentRepository;
            private readonly IMapper _mapper;
            public GetByIdEndContentQueryHandler(IEndContentRepository endContentRepository, IMapper mapper)
            {
                _endContentRepository = endContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<EndContentView>> Handle(GetByIdEndContentQuery request, CancellationToken cancellationToken)
            {
                var content = await _endContentRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<EndContentView>(content);
                return new SuccessServiceResponse<EndContentView>(viewModel);
            }
        }
    }
}
