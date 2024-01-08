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

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteProductCategory
{
    public class DeleteProductCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteProductCategoryCommandHandler :IRequestHandler<DeleteProductCategoryCommand,ServiceResponse<Guid>>
        {
            IProductCategoryRepository _productCategoryRepository;
            private readonly IMapper _mapper;
            public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
            {
                _productCategoryRepository = productCategoryRepository;
                _mapper = _mapper;   
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var productCategory = _mapper.Map<ProductCategory>(request);
                await _productCategoryRepository.DeleteAsync(productCategory);
                return new ServiceResponse<Guid>(productCategory.Id,Messages.CategoryDeleted);
            }
        }
    }
}
