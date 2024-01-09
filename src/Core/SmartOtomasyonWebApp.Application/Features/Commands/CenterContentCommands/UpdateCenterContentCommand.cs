using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CenterContentCommands
{
    public class UpdateCenterContentCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid HomeId { get; set; }

        public class UpdateCenterContentCommandHandler : IRequestHandler<UpdateCenterContentCommand, IDataResponse<Guid>>
        {
            ICenterContentRepository _centerContentRepository;
            private readonly IMapper _mapper;
            public UpdateCenterContentCommandHandler(ICenterContentRepository centerContentRepository, IMapper mapper)
            {
                _centerContentRepository = centerContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdateCenterContentCommand request, CancellationToken cancellationToken)
            {
                var content = _mapper.Map<CenterContent>(request);
                await _centerContentRepository.UpdateAsync(content);
                return new SuccessServiceResponse<Guid>(content.Id);
            }
        }
    }
}
