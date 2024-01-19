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

namespace SmartOtomasyonWebApp.Application.Features.Commands.MailCommands
{
    public class DeleteMailCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteMailCommandsHandler : IRequestHandler<DeleteMailCommand,IDataResponse<Guid>>
        {
            IMailBoxRepository _mailBoxRepository;
            private readonly IMapper _mapper;
            public DeleteMailCommandsHandler(IMailBoxRepository mailBoxRepository, IMapper mapper)
            {
                _mailBoxRepository = mailBoxRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(DeleteMailCommand request, CancellationToken cancellationToken)
            {
                var mail = _mapper.Map<MailBox>(request);
                await _mailBoxRepository.DeleteAsync(mail);
                return new SuccessServiceResponse<Guid>(mail.Id);
            }
        }
    }
}
