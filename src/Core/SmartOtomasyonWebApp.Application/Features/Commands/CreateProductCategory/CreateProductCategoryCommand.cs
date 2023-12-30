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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }

        public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, ServiceResponse<Guid>>
        {
            IProductCategoryRepository _productCategoryRepository;
            private readonly IMapper _mapper;
            public CreateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                _productCategoryRepository = productCategoryRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var productCategory = _mapper.Map<ProductCategory>(request);
                await _productCategoryRepository.AddAsync(productCategory);
                return new ServiceResponse<Guid>(productCategory.Id);
            }
        }

    }
}
