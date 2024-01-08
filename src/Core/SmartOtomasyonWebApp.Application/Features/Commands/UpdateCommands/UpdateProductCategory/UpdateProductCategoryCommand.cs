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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateProductCategory
{
    public class UpdateProductCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public class UpdateProductCategoryCommandHanadler : IRequestHandler<UpdateProductCategoryCommand,ServiceResponse<Guid>>
        {
            IProductCategoryRepository _productCategoryRepository;
            private readonly IMapper _mapper;
            public UpdateProductCategoryCommandHanadler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                _productCategoryRepository = productCategoryRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var productCategory = _mapper.Map<ProductCategory>(request);
                await _productCategoryRepository.UpdateAsync(productCategory);
                return new ServiceResponse<Guid>(productCategory.Id,Messages.CategoryUpdated);
            }
        }

    }
}
