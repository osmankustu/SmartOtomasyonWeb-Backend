using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateAbout
{
    public  class UpdateAboutCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImgUri { get; set; }

        public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, ServiceResponse<Guid>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public UpdateAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
            {
                var about = _mapper.Map<About>(request);
                await _aboutRepository.UpdateAsync(about);
                return new ServiceResponse<Guid>(about.Id);
            }
        }
    }
}
