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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetDocumentQueries
{
    public class GetAllDocumentQuery : IRequest<IDataResponse<List<DocumentView>>>
    {
        public class GetAllDocumentQueryHandler :IRequestHandler<GetAllDocumentQuery,IDataResponse<List<DocumentView>>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mappper;
            public GetAllDocumentQueryHandler(IDocumentRepository documentRepository, IMapper mappper)
            {
                _documentRepository = documentRepository;
                _mappper = mappper;
            }

            public async Task<IDataResponse<List<DocumentView>>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
            {
                var documents = await _documentRepository.GetAllAsync();
                var viewModel = _mappper.Map<List<DocumentView>>(documents);
                return new SuccessServiceResponse<List<DocumentView>>(viewModel);
            }
        }
    }
}
