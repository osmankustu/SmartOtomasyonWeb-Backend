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

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteAbout
{
    public class DeleteAboutCommand: IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, ServiceResponse<Guid>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public DeleteAboutCommandHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
            {
                var about = _mapper.Map<About>(request);
                await _aboutRepository.DeleteAsync(about);
                return new ServiceResponse<Guid>(about.Id);
            }
        }
    }
}
