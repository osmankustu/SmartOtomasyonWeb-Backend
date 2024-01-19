using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.DocumentCategoryCommands
{
    public class CreateDocumentCategoryCommand : IRequest<IDataResponse<Guid>>
    {
        public String Name { get; set; }
        public Guid PageId { get; set; }

        public class CreateDocumentCategoryCommandHandler : IRequestHandler<CreateDocumentCategoryCommand,IDataResponse<Guid>>
        {
            IDocumentCategoryRepository _documentCategoryRepository;
            private readonly IMapper _mapper;
            public CreateDocumentCategoryCommandHandler(IDocumentCategoryRepository documentCategoryRepository,IMapper mapper)
            {
                _documentCategoryRepository = documentCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateDocumentCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<DocumentCategory>(request);
                await _documentCategoryRepository.AddAsync(category);
                return new SuccessServiceResponse<Guid>(category.Id,Messages.CategoryAdded);
            }
        }
    }
}
