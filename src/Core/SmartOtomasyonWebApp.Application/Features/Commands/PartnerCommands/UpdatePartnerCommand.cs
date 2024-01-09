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

namespace SmartOtomasyonWebApp.Application.Features.Commands.PartnerCommands
{
    public class UpdatePartnerCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid HomeId { get; set; }

        public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand, IDataResponse<Guid>>
        {
            IPartnerRepository _parnerRepository;
            private readonly IMapper _mapper;
            public UpdatePartnerCommandHandler(IPartnerRepository parnerRepository, IMapper mapper)
            {
                _parnerRepository = parnerRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
            {
                var partner = _mapper.Map<Partner>(request);
                await _parnerRepository.UpdateAsync(partner);
                return new SuccessServiceResponse<Guid>(partner.Id);
            }
        }
    }
}
