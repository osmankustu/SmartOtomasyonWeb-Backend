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

namespace SmartOtomasyonWebApp.Application.Features.Commands.ReferanceCommands
{
    public class UpdateReferanceCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string SiteUri { get; set; }
        public Guid PageId { get; set; }
        public class UpdateReferanceCommandHandler : IRequestHandler<UpdateReferanceCommand, SuccessServiceResponse<Guid>>
        {
            IReferanceRepository _referanceRepository;
            private readonly IMapper _mapper;
            public UpdateReferanceCommandHandler(IReferanceRepository referanceRepository, IMapper mapper)
            {
                _referanceRepository = referanceRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdateReferanceCommand request, CancellationToken cancellationToken)
            {
                var referance = _mapper.Map<Referance>(request);
                await _referanceRepository.UpdateAsync(referance);
                return new SuccessServiceResponse<Guid>(referance.Id, Messages.ReferanceUpdated);
            }
        }
    }
}
