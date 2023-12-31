﻿using AutoMapper;
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
    public class GetAllMetaQuery  : IRequest<SuccessServiceResponse<List<MetaView>>>
    {
        public class GetAllMetaQueryHandler : IRequestHandler<GetAllMetaQuery,SuccessServiceResponse<List<MetaView>>>
        {
            IMetaRepository _metaRepository;
            private readonly IMapper _mapper;
            public GetAllMetaQueryHandler(IMetaRepository metaRepository,IMapper mapper)
            {
                _metaRepository = metaRepository;
                _mapper = mapper;   
            }

            public async Task<SuccessServiceResponse<List<MetaView>>> Handle(GetAllMetaQuery request, CancellationToken cancellationToken)
            {
                var metas = await _metaRepository.GetAllWithPageAsync();
                var viewModel = _mapper.Map<List<MetaView>>(metas);
                return new SuccessServiceResponse<List<MetaView>>(viewModel);
            }
        }
    }
}
