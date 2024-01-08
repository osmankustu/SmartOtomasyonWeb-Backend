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

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteReferance
{
    public class DeleteReferanceCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        //public String Title { get; set; }
        //public String Description { get; set; }
        //public String LogoUri { get; set; }
        //public String SiteUri { get; set; }
        //public DateTime CreateAt { get; set; }

        public class DeleteReferanceCommandHandler : IRequestHandler<DeleteReferanceCommand, ServiceResponse<Guid>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public DeleteReferanceCommandHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteReferanceCommand request, CancellationToken cancellationToken)
            {
                var referance = _mapper.Map<Referance>(request);
                await _referanceRepository.DeleteAsync(referance);
                return new ServiceResponse<Guid>(referance.Id,Messages.ReferanceDeleted);
            }
        }
    }
}
