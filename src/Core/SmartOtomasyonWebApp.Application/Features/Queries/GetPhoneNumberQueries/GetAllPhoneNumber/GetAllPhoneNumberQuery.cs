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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetPhoneNumberQueries.GetAllPhoneNumber
{
    public class GetAllPhoneNumberQuery : IRequest<ServiceResponse<List<PhoneNumberView>>>
    {
        public class GetAllPhoneNumberQueryHandler : IRequestHandler<GetAllPhoneNumberQuery, ServiceResponse<List<PhoneNumberView>>>
        {
            IPhoneNumberRepository _phoneNumberRepository;
            private readonly IMapper _mapper;
            public GetAllPhoneNumberQueryHandler(IPhoneNumberRepository phoneNumberRepository, IMapper mapper)
            {
                _phoneNumberRepository = phoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<PhoneNumberView>>> Handle(GetAllPhoneNumberQuery request, CancellationToken cancellationToken)
            {
                var numbers = await _phoneNumberRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<PhoneNumberView>>(numbers);
                return new ServiceResponse<List<PhoneNumberView>>(viewModel);
            }
        }
    }
}
