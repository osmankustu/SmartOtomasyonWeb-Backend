using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetByIdPublicPageQuery : IRequest<ServiceResponse<PublicPageView>>
    {
        public Guid Id { get; set; }

        public class GetByIdPublicQueryHandler: IRequestHandler<GetByIdPublicPageQuery,ServiceResponse<PublicPageView>>
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public GetByIdPublicQueryHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<PublicPageView>> Handle(GetByIdPublicPageQuery request, CancellationToken cancellationToken)
            {
                var page = await _pagesRepository.GetPageWithMetaAsync(request.Id);
                var viewModel = _mapper.Map<PublicPageView>(page);
                return new ServiceResponse<PublicPageView>(viewModel);
            }
        }
    }
}
