using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.MainSliderCommands
{
    public class CreateMainSliderCommand : IRequest<IDataResponse<Guid>>
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid HomeId { get; set; }

        public class CreateMainSliderQuwryHandler : IRequestHandler<CreateMainSliderCommand, IDataResponse<Guid>>
        {
            IMainSliderRepository _mainSliderRepository;
            private readonly IMapper _mapper;
            public CreateMainSliderQuwryHandler(IMainSliderRepository mainSliderRepository, IMapper mapper)
            {
                _mainSliderRepository = mainSliderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateMainSliderCommand request, CancellationToken cancellationToken)
            {
                var slider = _mapper.Map<MainSlider>(request);
                await _mainSliderRepository.AddAsync(slider);
                return new SuccessServiceResponse<Guid>(slider.Id);
            }
        }
    }
}
