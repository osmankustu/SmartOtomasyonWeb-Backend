using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicAboutQuery : IRequest<SuccessServiceResponse<List<PublicAboutView>>>
    {
        public class GetAllPublicAboutQueryHandler : IRequestHandler<GetAllPublicAboutQuery,SuccessServiceResponse<List<PublicAboutView>>>
        {
            IAboutRepository _aboutRepository;
            private readonly IMapper _mapper;
            public GetAllPublicAboutQueryHandler( IAboutRepository aboutRepository,IMapper mapper)
            {
                _aboutRepository = aboutRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<PublicAboutView>>> Handle(GetAllPublicAboutQuery request, CancellationToken cancellationToken)
            {
                var abouts = await _aboutRepository.GetAllAboutPublicAsync();
                var viewModel = _mapper.Map<List<PublicAboutView>>(abouts);
                return new SuccessServiceResponse<List<PublicAboutView>>(viewModel);

            }
        }
    }
}
