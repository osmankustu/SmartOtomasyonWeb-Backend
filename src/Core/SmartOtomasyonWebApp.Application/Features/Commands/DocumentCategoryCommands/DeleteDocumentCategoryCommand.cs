using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.DocumentCategoryCommands
{
    public class DeleteDocumentCategoryCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteDocumentCategoryCommandHandler : IRequestHandler<DeleteDocumentCategoryCommand, IDataResponse<Guid>>
        {
            IDocumentCategoryRepository _documentCategoryRepository;
            private readonly IMapper _mapper;
            public DeleteDocumentCategoryCommandHandler(IDocumentCategoryRepository documentCategoryRepository, IMapper mapper)
            {
                _documentCategoryRepository = documentCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(DeleteDocumentCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<DocumentCategory>(request);
                await _documentCategoryRepository.DeleteAsync(category);
                return new SuccessServiceResponse<Guid>(category.Id, Messages.CategoryDeleted);
            }
        }
    }
}
