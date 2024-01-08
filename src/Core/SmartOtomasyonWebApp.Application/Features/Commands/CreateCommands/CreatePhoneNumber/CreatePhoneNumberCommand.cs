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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreatePhoneNumber
{
    public class CreatePhoneNumberCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Phone { get; set; }
        public Guid FooterId { get; set; }

        public class CreatePhoneNumberCommandHandler : IRequestHandler<CreatePhoneNumberCommand,ServiceResponse<Guid>>
        {
            IPhoneNumberRepository _phoneNumberRepository;
            private readonly IMapper _mapper;
            public CreatePhoneNumberCommandHandler(IPhoneNumberRepository phoneNumberRepository, IMapper mapper)
            {
                _phoneNumberRepository = phoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreatePhoneNumberCommand request, CancellationToken cancellationToken)
            {
                var number = _mapper.Map<PhoneNumber>(request);
                 await _phoneNumberRepository.AddAsync(number);
                return new ServiceResponse<Guid>(number.Id,Messages.PhoneAdded);
            }
        }
    }
}
