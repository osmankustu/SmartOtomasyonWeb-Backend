﻿using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateSocialLink
{
    public class CreateSocialLinkCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid FooterId { get; set; }

        public class CreateSocialLinkCommandHandler : IRequestHandler<CreateSocialLinkCommand, ServiceResponse<Guid>>
        {
            ISocialLinksRepository _socialLinksRepository;
            private readonly IMapper _mapper;
            public CreateSocialLinkCommandHandler(ISocialLinksRepository socialLinksRepository, IMapper mapper)
            {
                _socialLinksRepository = socialLinksRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                var socialLink = _mapper.Map<SocialLinks>(request);
                await _socialLinksRepository.AddAsync(socialLink);
                return new ServiceResponse<Guid>(socialLink.Id,Messages.SocialAdded);
            }
        }
    }
}
