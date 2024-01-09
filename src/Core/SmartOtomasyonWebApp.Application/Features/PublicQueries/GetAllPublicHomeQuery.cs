using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicHomeQuery : IRequest<IDataResponse<List<PublicHomeView>>>
    {
        public class GetAllPublicHomeQueryHandler : IRequestHandler<GetAllPublicHomeQuery,IDataResponse<List<PublicHomeView>>>
        {
            IHomeRepository _homeRepository;
            private readonly IMapper _mapper;
            public GetAllPublicHomeQueryHandler(IHomeRepository homeRepository, IMapper mapper)
            {
                _homeRepository = homeRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicHomeView>>> Handle(GetAllPublicHomeQuery request, CancellationToken cancellationToken)
            {
                var homes = await _homeRepository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicHomeView>>(homes);
                return new SuccessServiceResponse<List<PublicHomeView>>(viewModel);
            }
        }

        
    }
}
