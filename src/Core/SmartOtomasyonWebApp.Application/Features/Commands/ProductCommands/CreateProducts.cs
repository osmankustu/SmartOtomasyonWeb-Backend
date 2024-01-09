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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String ImgUri { get; set; }
        public String Description { get; set; }
        public String UserManualUri { get; set; }
        public String TechDocumentUri { get; set; }
        public Guid ProductCategoryId { get; set; }

        public class CreateProductCommandHandler :IRequestHandler<CreateProductCommand,SuccessServiceResponse<Guid>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(IProductRepository productRepository ,IMapper mapper)
            {
               _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                
                var product = _mapper.Map <Product> (request);
                await _productRepository.AddAsync(product);
                return new SuccessServiceResponse<Guid>(product.Id,Messages.ProductAdded);
            }
        }
    }
}
