using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Aspects;
using SmartOtomasyonWebApp.Application.Dto.About;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries
{

    public class GetByIdAboutQuery : IRequest<SuccessServiceResponse<AboutView>>
    {
        public Guid Id { get; set; }

        public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, SuccessServiceResponse<AboutView>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public GetByIdAboutQueryHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }


            public async Task<SuccessServiceResponse<AboutView>> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
            {
                var about = await _aboutRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<AboutView>(about);
                return new SuccessServiceResponse<AboutView>(viewModel);
            }
        }
    }
}
