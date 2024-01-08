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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries.GetAllAbout
{
    public class GetAllAboutQuery : IRequest<ServiceResponse<List<AboutView>>>
    {

        public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQuery, ServiceResponse<List<AboutView>>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public GetAllAboutQueryHandler(IAboutRepository aboutRepository, IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<AboutView>>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
            {
                var about = await _aboutRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<AboutView>>(about);
                return new ServiceResponse<List<AboutView>>(viewModel);
            }
        }
    }
}
