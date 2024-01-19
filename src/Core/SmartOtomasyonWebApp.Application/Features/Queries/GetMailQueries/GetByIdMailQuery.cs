using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.Mail;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetMailQueries
{
    public class GetByIdMailQuery : IRequest<IDataResponse<MailView>>
    {
        public Guid Id { get; set; }
        public class GetByIdMailQueryHandler : IRequestHandler<GetByIdMailQuery,IDataResponse<MailView>>
        {
            IMailBoxRepository _mailBoxRepository;
            private readonly IMapper _mapper;
            public GetByIdMailQueryHandler(IMailBoxRepository mailBoxRepository,IMapper mapper)
            {
                _mailBoxRepository = mailBoxRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<MailView>> Handle(GetByIdMailQuery request, CancellationToken cancellationToken)
            {
                var mail = await _mailBoxRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<MailView>(mail);
                return new SuccessServiceResponse<MailView>(viewModel);
            }
        }
    }
}
