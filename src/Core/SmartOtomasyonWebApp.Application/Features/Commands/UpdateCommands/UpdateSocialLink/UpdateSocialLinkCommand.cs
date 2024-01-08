using AutoMapper;
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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateSocialLink
{
    public class UpdateSocialLinkCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid FooterId { get; set; }

        public class UpdateSocialLinkCommandHandler : IRequestHandler<UpdateSocialLinkCommand, ServiceResponse<Guid>>
        {
            ISocialLinksRepository _socialLinksRepository;
            private IMapper _mapper;
            public UpdateSocialLinkCommandHandler(ISocialLinksRepository socialLinksRepository, IMapper mapper)
            {
                _socialLinksRepository = socialLinksRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                var link = _mapper.Map<SocialLinks>(request);
                await _socialLinksRepository.UpdateAsync(link);
                return new ServiceResponse<Guid>(link.Id, Messages.SocialUpdaded);
            }
        }
    }
}
