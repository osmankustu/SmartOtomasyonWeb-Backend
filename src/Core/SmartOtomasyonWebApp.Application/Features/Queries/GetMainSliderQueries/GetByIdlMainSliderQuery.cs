using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.MainSliderDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetMainSliderQueries
{
    public class GetByIdlMainSliderQuery : IRequest<IDataResponse<MainSliderView>>
    {
        public Guid Id { get; set; }
        public class GetByIdMainSliderQueryHandler : IRequestHandler<GetByIdlMainSliderQuery, IDataResponse<MainSliderView>>
        {
            IMainSliderRepository _mainSliderRepository;
            private readonly IMapper _mapper;
            public GetByIdMainSliderQueryHandler(IMainSliderRepository mainSliderRepository, IMapper mapper)
            {
                _mainSliderRepository = mainSliderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<MainSliderView>> Handle(GetByIdlMainSliderQuery request, CancellationToken cancellationToken)
            {
                var sliders = await _mainSliderRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<MainSliderView>(sliders);
                return new SuccessServiceResponse<MainSliderView>(viewModel);
            }
        }
    }
}
