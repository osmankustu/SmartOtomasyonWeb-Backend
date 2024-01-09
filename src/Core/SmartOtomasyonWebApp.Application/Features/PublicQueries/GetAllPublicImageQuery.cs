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
    public class GetAllPublicImageQuery : IRequest<IDataResponse<List<PublicImageView>>>
    {
        public class GetAllPublicImageQueryHandler : IRequestHandler<GetAllPublicImageQuery,IDataResponse<List<PublicImageView>>>
        {
            IWorkImagesRepository _repository;
            private readonly IMapper _mapper;
            public GetAllPublicImageQueryHandler(IWorkImagesRepository workImagesRepository,IMapper mapper)
            {
                _repository = workImagesRepository;
                _mapper = mapper;

            }

            public async Task<IDataResponse<List<PublicImageView>>> Handle(GetAllPublicImageQuery request, CancellationToken cancellationToken)
            {
                var images = await _repository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicImageView>>(images);
                return new SuccessServiceResponse<List<PublicImageView>>(viewModel);
            }
        }
    }
}
