﻿using AutoMapper;
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
    public class GetAllSocialLinkQuery : IRequest<SuccessServiceResponse<List<SocialLinkView>>>
    {
        public class GetAllSocialLinkQueryHandler : IRequestHandler<GetAllSocialLinkQuery, SuccessServiceResponse<List<SocialLinkView>>>
        {
            ISocialLinksRepository _socialLinksRepository;
            private readonly IMapper _mapper;
            public GetAllSocialLinkQueryHandler(ISocialLinksRepository socialLinksRepository, IMapper mapper)
            {
                _socialLinksRepository = socialLinksRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<SocialLinkView>>> Handle(GetAllSocialLinkQuery request, CancellationToken cancellationToken)
            {
                var socialLinks = await _socialLinksRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<SocialLinkView>>(socialLinks);
                return new SuccessServiceResponse<List<SocialLinkView>>(viewModel);
            }
        }
    }
}
