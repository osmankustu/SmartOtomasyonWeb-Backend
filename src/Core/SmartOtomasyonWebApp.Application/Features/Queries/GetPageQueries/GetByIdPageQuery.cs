using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PageDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetPageQueries
{
    public class GetByIdPageQuery : IRequest<ServiceResponse<PageView>>
    {
        public Guid Id { get; set; }
        public class GetAllPageQueryHandler : IRequestHandler<GetByIdPageQuery, ServiceResponse<PageView>>
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public GetAllPageQueryHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<PageView>> Handle(GetByIdPageQuery request, CancellationToken cancellationToken)
            {
                var pages = await _pagesRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<PageView>(pages);
                return new ServiceResponse<PageView>(viewModel);
            }
        }
    }
}
