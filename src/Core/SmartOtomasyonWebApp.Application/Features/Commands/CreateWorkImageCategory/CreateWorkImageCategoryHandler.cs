using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImageCategory
{
    public class CreateWorkImageCategoryHandler : IRequestHandler<CreateWorkImageCategoryCommand,ServiceResponse<Guid>>
    {
        IWorkImageCategoryRepository _workImageCategoryRepository;
        private readonly IMapper _mapper;
        public CreateWorkImageCategoryHandler(IWorkImageCategoryRepository workImageCategoryRepository, IMapper mapper)
        {
            _workImageCategoryRepository = workImageCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateWorkImageCategoryCommand request, CancellationToken cancellationToken)
        {
            var workImageCategory = _mapper.Map<WorkImageCategory>(request);
            await _workImageCategoryRepository.AddAsync(workImageCategory);
            return new ServiceResponse<Guid>(workImageCategory.Id);
        }
    }
}
