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

namespace SmartOtomasyonWebApp.Application.Features.Commands.ProductCategoryCommands
{
    public class DeleteProductCategoryCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, SuccessServiceResponse<Guid>>
        {
            IProductCategoryRepository _productCategoryRepository;
            private readonly IMapper _mapper;
            public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                _productCategoryRepository = productCategoryRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var productCategory = _mapper.Map<ProductCategory>(request);
                await _productCategoryRepository.DeleteAsync(productCategory);
                return new SuccessServiceResponse<Guid>(productCategory.Id, Messages.CategoryDeleted);
            }
        }
    }
}
