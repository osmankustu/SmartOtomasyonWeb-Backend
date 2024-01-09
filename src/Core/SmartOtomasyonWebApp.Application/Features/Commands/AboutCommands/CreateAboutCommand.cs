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
    public class CreateAboutCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String ImgUri { get; set; }
        public Guid PageId { get; set; }

        public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, SuccessServiceResponse<Guid>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public CreateAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
            {
                var about = _mapper.Map<About>(request);
                await _aboutRepository.AddAsync(about);
                return new SuccessServiceResponse<Guid>(about.Id);
            }
        }
    }
}
