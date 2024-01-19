using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DocumentDto;
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
    public class GetAllPublicDocumentQuery : IRequest<IDataResponse<List<DocumentView>>>
    {
        public class GetAllPublicDocumentQueryHandler : IRequestHandler<GetAllPublicDocumentQuery, IDataResponse<List<DocumentView>>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mappper;
            public GetAllPublicDocumentQueryHandler(IDocumentRepository documentRepository, IMapper mappper)
            {
                _documentRepository = documentRepository;
                _mappper = mappper;
            }

            public async Task<IDataResponse<List<DocumentView>>> Handle(GetAllPublicDocumentQuery request, CancellationToken cancellationToken)
            {
                var documents = await _documentRepository.getPublicAsync();
                var viewModel = _mappper.Map<List<DocumentView>>(documents);
                return new SuccessServiceResponse<List<DocumentView>>(viewModel);
            }
        }
    }
}
