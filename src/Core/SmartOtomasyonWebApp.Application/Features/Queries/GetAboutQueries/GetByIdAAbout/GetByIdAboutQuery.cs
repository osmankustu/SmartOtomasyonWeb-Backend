using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.About;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries.GetByIdAAbout
{
    public class GetByIdAboutQuery : IRequest<ServiceResponse<AboutView>>
    {
        public Guid Id{ get; set; }

        public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery,ServiceResponse<AboutView>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public GetByIdAboutQueryHandler(IAboutRepository aboutRepository,IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<AboutView>> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
            {
                var about = await _aboutRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<AboutView>(about);
                return new ServiceResponse<AboutView>(viewModel);
            }
        }
    }
}
