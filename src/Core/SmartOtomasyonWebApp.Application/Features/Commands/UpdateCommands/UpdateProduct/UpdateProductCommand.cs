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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String ImgUri { get; set; }
        public String Description { get; set; }
        public String UserManualUri { get; set; }
        public String TechDocumentUri { get; set; }
        public Guid ProductCategoryId { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,ServiceResponse<Guid>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public UpdateProductCommandHandler(IProductRepository productRepository,IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                await _productRepository.UpdateAsync(product);
                return new ServiceResponse<Guid>(product.Id,Messages.ProductUpdaded);
            }
        }
    }
}
