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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateWorkImageCategory
{
    public class UpdateWorkImageCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public class UpdateWorkImageCategoryCommandHandler : IRequestHandler<UpdateWorkImageCategoryCommand, ServiceResponse<Guid>>
        {
            IWorkImageCategoryRepository _workImageCategoryRepository;
            private readonly IMapper _mapper;
            public UpdateWorkImageCategoryCommandHandler(IWorkImageCategoryRepository workImageCategoryRepository, IMapper mapper)
            {
                _workImageCategoryRepository = workImageCategoryRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateWorkImageCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<WorkImageCategory>(request);
                await _workImageCategoryRepository.UpdateAsync(category);
                return new ServiceResponse<Guid>(category.Id,Messages.CategoryUpdated);
            }
        }
    }
}
