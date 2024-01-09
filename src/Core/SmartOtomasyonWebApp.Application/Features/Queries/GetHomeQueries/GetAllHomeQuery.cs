using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.HomeDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetHomeQueries
{
    public class GetAllHomeQuery : IRequest<IDataResponse<List<HomeView>>>
    {
        public class GetAllHomeQueryHandler:IRequestHandler<GetAllHomeQuery,IDataResponse<List<HomeView>>>
        {
            IHomeRepository _homeRepository;
            private readonly IMapper _mapper;
            public GetAllHomeQueryHandler(IHomeRepository homeRepository, IMapper mapper)
            {
                _homeRepository = homeRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<HomeView>>> Handle(GetAllHomeQuery request, CancellationToken cancellationToken)
            {
                var homes = await _homeRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<HomeView>>(homes);
                return new SuccessServiceResponse<List<HomeView>>(viewModel);
            }
        }
    }
}
