using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.MainSliderDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetMainSliderQueries
{
    public class GetAllMainSliderQuery : IRequest<IDataResponse<List<MainSliderView>>>
    {
        public class GetAllMainSliderQueryHandler: IRequestHandler<GetAllMainSliderQuery, IDataResponse<List<MainSliderView>>>
        {
            IMainSliderRepository _mainSliderRepository;
            private readonly IMapper _mapper;
            public GetAllMainSliderQueryHandler(IMainSliderRepository mainSliderRepository, IMapper mapper)
            {
                _mainSliderRepository = mainSliderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<MainSliderView>>> Handle(GetAllMainSliderQuery request, CancellationToken cancellationToken)
            {
                var sliders = await _mainSliderRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<MainSliderView>>(sliders);
                return new SuccessServiceResponse<List<MainSliderView>>(viewModel);
            }
        }
    }
}
