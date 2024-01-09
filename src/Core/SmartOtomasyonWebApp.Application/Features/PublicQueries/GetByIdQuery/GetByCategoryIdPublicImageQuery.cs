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

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries.GetByIdQuery
{
    public class GetByCategoryIdPublicImageQuery : IRequest<IDataResponse<List<PublicImageView>>>
    {
        public Guid Id { get; set; }
        public class GetByCategoryIdImageQueryHandler : IRequestHandler<GetByCategoryIdPublicImageQuery,IDataResponse<List<PublicImageView>>>
        {
            IWorkImagesRepository _repository;
            private readonly IMapper _mapper;
            public GetByCategoryIdImageQueryHandler(IWorkImagesRepository workImagesRepository,IMapper mapper)
            {
                _repository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicImageView>>> Handle(GetByCategoryIdPublicImageQuery request, CancellationToken cancellationToken)
            {
                var images = await _repository.GetByCategoryIdAsync(request.Id);
                var vievModel = _mapper.Map<List<PublicImageView>>(images);
                return new SuccessServiceResponse<List<PublicImageView>>(vievModel);
            }
        }
    }
}
