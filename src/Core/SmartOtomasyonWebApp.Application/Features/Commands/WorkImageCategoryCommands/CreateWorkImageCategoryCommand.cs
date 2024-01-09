using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Aspects;
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
    
    public class CreateWorkImageCategoryCommand :IRequest<SuccessServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public Guid pageId { get; set; }
        public class CreateWorkImageCategoryHandler : IRequestHandler<CreateWorkImageCategoryCommand, SuccessServiceResponse<Guid>>
        {
            IWorkImageCategoryRepository _workImageCategoryRepository;
            private readonly IMapper _mapper;


            public CreateWorkImageCategoryHandler(IWorkImageCategoryRepository workImageCategoryRepository, IMapper mapper)
            {
                _workImageCategoryRepository = workImageCategoryRepository;
                _mapper = mapper;
            }


            public async Task<SuccessServiceResponse<Guid>> Handle(CreateWorkImageCategoryCommand request, CancellationToken cancellationToken)
            {
                var workImageCategory = _mapper.Map<WorkImageCategory>(request);
                await _workImageCategoryRepository.AddAsync(workImageCategory);
                return new SuccessServiceResponse<Guid>(workImageCategory.Id);
            }
        }
    }
}
