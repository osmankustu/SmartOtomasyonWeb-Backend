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
    public class GetAllMailQuery : IRequest<IDataResponse<List<MailView>>>
    {
        public class GetAllMailQueryHandler : IRequestHandler<GetAllMailQuery, IDataResponse<List<MailView>>>
        {
            IMailBoxRepository _mailBoxRepository;
            private readonly IMapper _mapper;
            public GetAllMailQueryHandler(IMailBoxRepository mailBoxRepository, IMapper mapper)
            {
                _mailBoxRepository = mailBoxRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<MailView>>> Handle(GetAllMailQuery request, CancellationToken cancellationToken)
            {
                var mails = await _mailBoxRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<MailView>>(mails);
                viewModel.Reverse();
                return new SuccessServiceResponse<List<MailView>>(viewModel);
            }
        }
    }
}
