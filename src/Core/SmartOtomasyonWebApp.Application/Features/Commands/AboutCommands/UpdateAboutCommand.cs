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

namespace SmartOtomasyonWebApp.Application.Features.Commands.AboutCommands
{
    public class UpdateAboutCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUri { get; set; }
        public Guid PageId { get; set; }

        public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, SuccessServiceResponse<Guid>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public UpdateAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
            {
                var about = _mapper.Map<About>(request);
                await _aboutRepository.UpdateAsync(about);
                return new SuccessServiceResponse<Guid>(about.Id);
            }
        }
    }
}
