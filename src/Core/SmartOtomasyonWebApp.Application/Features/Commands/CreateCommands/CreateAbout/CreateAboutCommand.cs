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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateAbout
{
    public class CreateAboutCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImgUri { get; set; }

        public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, ServiceResponse<Guid>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public CreateAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
            {
                var about = _mapper.Map<About>(request);
                await _aboutRepository.AddAsync(about);
                return new ServiceResponse<Guid>(about.Id);
            }
        }
    }
}
