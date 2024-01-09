using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.SocialLink;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetSocialLinksQueries
{
    public class GetByIdSocialLinkQuery : IRequest<SuccessServiceResponse<SocialLinkView>>
    {
        public Guid Id { get; set; }

        public class GetByIdSocialLinkQueryHandler : IRequestHandler<GetByIdSocialLinkQuery, SuccessServiceResponse<SocialLinkView>>
        {
            ISocialLinksRepository _socialLinksRepository;
            private readonly IMapper _mapper;
            public GetByIdSocialLinkQueryHandler(ISocialLinksRepository socialLinksRepository, IMapper mapper)
            {
                _socialLinksRepository = socialLinksRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<SocialLinkView>> Handle(GetByIdSocialLinkQuery request, CancellationToken cancellationToken)
            {
                var links = await _socialLinksRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<SocialLinkView>(links);
                return new SuccessServiceResponse<SocialLinkView>(viewModel);
            }
        }
    }
}
