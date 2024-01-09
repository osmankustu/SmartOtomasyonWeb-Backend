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
    public class GetAllPageQuery : IRequest<SuccessServiceResponse<List<PageView>>>
    {
        public class GetAllPageQueryHandler : IRequestHandler<GetAllPageQuery,SuccessServiceResponse<List<PageView>>>
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public GetAllPageQueryHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<PageView>>> Handle(GetAllPageQuery request, CancellationToken cancellationToken)
            {
                var pages = await _pagesRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<PageView>>(pages);
                return new SuccessServiceResponse<List<PageView>>(viewModel);
            }
        }
    }
}
