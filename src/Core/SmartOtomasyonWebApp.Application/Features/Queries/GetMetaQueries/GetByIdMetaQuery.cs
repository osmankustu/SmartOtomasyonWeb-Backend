using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.MetaDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetMetaQueries
{
    public class GetByIdMetaQuery : IRequest<ServiceResponse<MetaView>>
    {
        public Guid Id { get; set; }
        public class GetByIdMetaQueryHandler : IRequestHandler<GetByIdMetaQuery, ServiceResponse<MetaView>>
        {
            IMetaRepository _metaRepository;
            private readonly IMapper _mapper;
            public GetByIdMetaQueryHandler(IMetaRepository metaRepository, IMapper mapper)
            {
                _metaRepository = metaRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<MetaView>> Handle(GetByIdMetaQuery request, CancellationToken cancellationToken)
            {
                var metas = await _metaRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<MetaView>(metas);
                return new ServiceResponse<MetaView>(viewModel);
            }
        }
    }
}
