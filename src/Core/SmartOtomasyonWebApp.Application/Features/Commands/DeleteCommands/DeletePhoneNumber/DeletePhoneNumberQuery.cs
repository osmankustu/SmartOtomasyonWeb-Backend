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

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeletePhoneNumber
{
    public class DeletePhoneNumberCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeletePhoneNumberCommandHandler : IRequestHandler<DeletePhoneNumberCommand,ServiceResponse<Guid>>
        {
            IPhoneNumberRepository _phoneNumberRepository;
            private readonly IMapper _mapper;
            public DeletePhoneNumberCommandHandler(IPhoneNumberRepository phoneNumberRepository,IMapper mapper)
            {
                _phoneNumberRepository = phoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
            {
                var number = _mapper.Map<PhoneNumber>(request);
                await _phoneNumberRepository.DeleteAsync(number);
                return new ServiceResponse<Guid>(number.Id,Messages.PhonelDeleted);
            }
        }
    }
}
