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
    public class DeleteMainSliderCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteMainSliderQuwryHandler : IRequestHandler<DeleteMainSliderCommand, IDataResponse<Guid>>
        {
            IMainSliderRepository _mainSliderRepository;
            private readonly IMapper _mapper;
            public DeleteMainSliderQuwryHandler(IMainSliderRepository mainSliderRepository, IMapper mapper)
            {
                _mainSliderRepository = mainSliderRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(DeleteMainSliderCommand request, CancellationToken cancellationToken)
            {
                var slider = _mapper.Map<MainSlider>(request);
                await _mainSliderRepository.DeleteAsync(slider);
                return new SuccessServiceResponse<Guid>(slider.Id);
            }
        }
    }
}
