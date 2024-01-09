using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PhoneNumberDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetPhoneNumberQueries
{
    public class GetByIdPhoneNumberQuery : IRequest<SuccessServiceResponse<PhoneNumberView>>
    {
        public Guid Id { get; set; }
        public class GetByIdPhoneNumberQueryHandler : IRequestHandler<GetByIdPhoneNumberQuery, SuccessServiceResponse<PhoneNumberView>>
        {
            IPhoneNumberRepository _phoneNumberRepository;
            private readonly IMapper _mapper;
            public GetByIdPhoneNumberQueryHandler(IPhoneNumberRepository phoneNumberRepository, IMapper mapper)
            {
                _phoneNumberRepository = phoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<PhoneNumberView>> Handle(GetByIdPhoneNumberQuery request, CancellationToken cancellationToken)
            {
                var number = await _phoneNumberRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<PhoneNumberView>(number);
                return new SuccessServiceResponse<PhoneNumberView>(viewModel);
            }
        }
    }
}
