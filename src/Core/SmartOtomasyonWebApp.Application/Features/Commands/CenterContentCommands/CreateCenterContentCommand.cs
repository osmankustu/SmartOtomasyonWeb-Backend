using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.CenterContentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartOtomasyonWebApp.Domain.Entities;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateCenterContent
{
    public class CreateCenterContentCommand : IRequest<IDataResponse<Guid>>
    {
        public string SiteName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid HomeId { get; set; }

        public class CreateCenterContentCommandHandler : IRequestHandler<CreateCenterContentCommand, IDataResponse<Guid>>
        {
            ICenterContentRepository _centerContentRepository;
            private readonly IMapper _mapper;
            public CreateCenterContentCommandHandler(ICenterContentRepository centerContentRepository, IMapper mapper)
            {
                _centerContentRepository = centerContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateCenterContentCommand request, CancellationToken cancellationToken)
            {
                var content = _mapper.Map<CenterContent>(request);
                await _centerContentRepository.AddAsync(content);
                return new SuccessServiceResponse<Guid>(content.Id);
            }
        }
    }
}
