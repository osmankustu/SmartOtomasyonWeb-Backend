using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DocumentCategoryDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.PublicQueries
{
    public class GetAllPublicDocumentCategoryQuery : IRequest<IDataResponse<List<DocumentCategoryView>>>
    {
        public class GetAllPublicDocumentCategoryQueryHandler : IRequestHandler<GetAllPublicDocumentCategoryQuery, IDataResponse<List<DocumentCategoryView>>>
        {
            IDocumentCategoryRepository _documentCategoryRepository;
            private readonly IMapper _mapper;
            public GetAllPublicDocumentCategoryQueryHandler(IDocumentCategoryRepository documentCategoryRepository, IMapper mapper)
            {
                _documentCategoryRepository = documentCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<DocumentCategoryView>>> Handle(GetAllPublicDocumentCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _documentCategoryRepository.getAllPublicAsync();
                var viewModel = _mapper.Map<List<DocumentCategoryView>>(categories);
                return new SuccessServiceResponse<List<DocumentCategoryView>>(viewModel);
            }
        }

    }
}
