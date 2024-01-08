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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdatePhoneNumber
{
    public class UpdatePhoneNumberCommand :  IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Phone { get; set; }
        public Guid FooterId { get; set; }

        public class UpdatePhoneNumberCommandHandler : IRequestHandler<UpdatePhoneNumberCommand,ServiceResponse<Guid>>
        {
            IPhoneNumberRepository _phoneNumberRepository;
            private readonly IMapper _mapper;
            public UpdatePhoneNumberCommandHandler(IPhoneNumberRepository phoneNumberRepository, IMapper mapper)
            {
                _phoneNumberRepository = phoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
            {
                var number = _mapper.Map<PhoneNumber>(request);
                await _phoneNumberRepository.UpdateAsync(number);
                return new ServiceResponse<Guid>(number.Id,Messages.PhoneUpdaded);
            }
        }

    }
}
