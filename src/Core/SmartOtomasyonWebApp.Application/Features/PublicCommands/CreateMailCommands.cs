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

namespace SmartOtomasyonWebApp.Application.Features.PublicCommands
{
    public class CreateMailCommands : IRequest<IDataResponse<Guid>>
    {
        public String NameSureName { get; set; }
        public String Email { get; set; }
        public String Message { get; set; }
        public String Subject { get; set; }
        public String phone { get; set; }

        public class CreateMailCommandsHandler :IRequestHandler<CreateMailCommands,IDataResponse<Guid>>
        {
            IMailBoxRepository _mailBoxRepository;
            private readonly IMapper _mapper;
            public CreateMailCommandsHandler(IMailBoxRepository mailBoxRepository, IMapper mapper)
            {
                _mailBoxRepository = mailBoxRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateMailCommands request, CancellationToken cancellationToken)
            {
                var mail = _mapper.Map<MailBox>(request);
                mail.IsRead = false;
                await _mailBoxRepository.PublicAddAsync(mail);
                return new SuccessServiceResponse<Guid>(mail.Id, "Mesajınız Aalınmıştır. En Kısa Sürede iletişime Geçeceğiz...");
            }
        }
    }
}
