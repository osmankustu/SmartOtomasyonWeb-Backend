using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.MainSliderCommands
{
    public class UpdateMainSliderCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid HomeId { get; set; }

        public class UpdateMainSliderQuwryHandler : IRequestHandler<UpdateMainSliderCommand, IDataResponse<Guid>>
        {
            IMainSliderRepository _mainSliderRepository;
            private readonly IMapper _mapper;
            public UpdateMainSliderQuwryHandler(IMainSliderRepository mainSliderRepository, IMapper mapper)
            {
                _mainSliderRepository = mainSliderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdateMainSliderCommand request, CancellationToken cancellationToken)
            {
                var slider = _mapper.Map<MainSlider>(request);
                await _mainSliderRepository.UpdateAsync(slider);
                return new SuccessServiceResponse<Guid>(slider.Id);
            }
        }
    }
}
