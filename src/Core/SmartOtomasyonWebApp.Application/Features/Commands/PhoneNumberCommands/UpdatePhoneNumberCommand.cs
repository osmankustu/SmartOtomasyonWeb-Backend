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

namespace SmartOtomasyonWebApp.Application.Features.Commands.PhoneNumberCommands
{
    public class UpdatePhoneNumberCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Guid FooterId { get; set; }

        public class UpdatePhoneNumberCommandHandler : IRequestHandler<UpdatePhoneNumberCommand, SuccessServiceResponse<Guid>>
        {
            IPhoneNumberRepository _phoneNumberRepository;
            private readonly IMapper _mapper;
            public UpdatePhoneNumberCommandHandler(IPhoneNumberRepository phoneNumberRepository, IMapper mapper)
            {
                _phoneNumberRepository = phoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
            {
                var number = _mapper.Map<PhoneNumber>(request);
                await _phoneNumberRepository.UpdateAsync(number);
                return new SuccessServiceResponse<Guid>(number.Id, Messages.PhoneUpdaded);
            }
        }

    }
}
