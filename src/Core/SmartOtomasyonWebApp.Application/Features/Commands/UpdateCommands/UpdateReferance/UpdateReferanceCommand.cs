using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateReferance
{
    public class UpdateReferanceCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String LogoUri { get; set; }
        public String SiteUri { get; set; }
        public class UpdateReferanceCommandHandler: IRequestHandler<UpdateReferanceCommand, ServiceResponse<Guid>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public UpdateReferanceCommandHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateReferanceCommand request, CancellationToken cancellationToken)
            {
                var referance = _mapper.Map<Referance>(request);
                await _referanceRepository.UpdateAsync(referance);
                return new ServiceResponse<Guid>(referance.Id,Messages.ReferanceUpdated);
            }
        }
    }
}
