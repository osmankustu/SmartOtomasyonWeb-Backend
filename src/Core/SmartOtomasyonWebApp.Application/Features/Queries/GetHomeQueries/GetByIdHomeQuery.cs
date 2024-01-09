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
    public class GetByIdHomeQuery :IRequest<IDataResponse<HomeView>>
    {
        public Guid Id { get; set; }
        public class GetByIdHomeQueryHandler : IRequestHandler<GetByIdHomeQuery,IDataResponse<HomeView>>
        {
            IHomeRepository _homeRepository;
            private readonly IMapper _mapper;
            public GetByIdHomeQueryHandler(IHomeRepository homeRepository,IMapper mapper)
            {
                _homeRepository = homeRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<HomeView>> Handle(GetByIdHomeQuery request, CancellationToken cancellationToken)
            {
                var home = await _homeRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<HomeView>(home);
                return new SuccessServiceResponse<HomeView>(viewModel);
            }
        }
    }
}
