using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.PartnerCommands
{
    public class CreatePartnerCommand :IRequest<IDataResponse<Guid>>
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid HomeId { get; set; }

        public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, IDataResponse<Guid>>
        {
            IPartnerRepository _parnerRepository;
            private readonly IMapper _mapper;
            public CreatePartnerCommandHandler(IPartnerRepository parnerRepository, IMapper mapper)
            {
                _parnerRepository = parnerRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
            {
                var partner = _mapper.Map<Partner>(request);
                await _parnerRepository.AddAsync(partner);
                return new SuccessServiceResponse<Guid>(partner.Id);  
            }
        }
    }
}
