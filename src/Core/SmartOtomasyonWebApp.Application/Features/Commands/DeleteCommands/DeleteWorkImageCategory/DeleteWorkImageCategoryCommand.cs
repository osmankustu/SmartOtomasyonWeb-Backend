using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteWorkImageCategory
{
    public class DeleteWorkImageCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public class DeleteWorkImageCategoryCommandHandler : IRequestHandler<DeleteWorkImageCategoryCommand, ServiceResponse<Guid>>
        {
            IWorkImageCategoryRepository _workImageCategoryRepository;
            private readonly IMapper _mapper;
            public DeleteWorkImageCategoryCommandHandler(IWorkImageCategoryRepository workImageCategoryRepository, IMapper mapper)
            {
                _workImageCategoryRepository = workImageCategoryRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteWorkImageCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<WorkImageCategory>(request);
                await _workImageCategoryRepository.DeleteAsync(category);
                return new ServiceResponse<Guid>(category.Id,Messages.CategoryDeleted);
            }
        }
    }
}
