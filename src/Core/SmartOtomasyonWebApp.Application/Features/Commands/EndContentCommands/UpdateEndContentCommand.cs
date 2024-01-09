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

namespace SmartOtomasyonWebApp.Application.Features.Commands.EndContentCommands
{
    public class UpdateEndContentCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String SiteName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid HomeId { get; set; }

        public class UpdateEndContentCommandHandler : IRequestHandler<UpdateEndContentCommand, IDataResponse<Guid>>
        {
            IEndContentRepository _endContentRepository;
            private readonly IMapper _mapper;
            public UpdateEndContentCommandHandler(IEndContentRepository endContentRepository, IMapper mapper)
            {
                _endContentRepository = endContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdateEndContentCommand request, CancellationToken cancellationToken)
            {
                var content = _mapper.Map<EndContent>(request);
                await _endContentRepository.UpdateAsync(content);
                return new SuccessServiceResponse<Guid>(content.Id);
            }
        }
    }
}
