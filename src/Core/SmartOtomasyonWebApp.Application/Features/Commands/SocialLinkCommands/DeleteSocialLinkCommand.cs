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

namespace SmartOtomasyonWebApp.Application.Features.Commands.SocialLinkCommands
{
    public class DeleteSocialLinkCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteSocialLinkCommandHandler : IRequestHandler<DeleteSocialLinkCommand, SuccessServiceResponse<Guid>>
        {
            ISocialLinksRepository _socialLinksRepository;
            private readonly IMapper _mapper;
            public DeleteSocialLinkCommandHandler(ISocialLinksRepository socialLinksRepository, IMapper mapper)
            {
                _socialLinksRepository = socialLinksRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(DeleteSocialLinkCommand request, CancellationToken cancellationToken)
            {
                var link = _mapper.Map<SocialLinks>(request);
                await _socialLinksRepository.DeleteAsync(link);
                return new SuccessServiceResponse<Guid>(link.Id, Messages.SocialDeleted);
            }
        }
    }
}
