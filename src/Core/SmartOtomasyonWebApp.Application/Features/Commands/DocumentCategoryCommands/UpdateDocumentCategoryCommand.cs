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
    public class UpdateDocumentCategoryCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Guid PageId { get; set; }

        public class UpdateDocumentCategoryCommandHandler : IRequestHandler<UpdateDocumentCategoryCommand, IDataResponse<Guid>>
        {
            IDocumentCategoryRepository _documentCategoryRepository;
            private readonly IMapper _mapper;
            public UpdateDocumentCategoryCommandHandler(IDocumentCategoryRepository documentCategoryRepository, IMapper mapper)
            {
                _documentCategoryRepository = documentCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdateDocumentCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<DocumentCategory>(request);
                await _documentCategoryRepository.UpdateAsync(category);
                return new SuccessServiceResponse<Guid>(category.Id, Messages.CategoryUpdated);
            }
        }
    }
}
