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

namespace SmartOtomasyonWebApp.Application.Features.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public string Description { get; set; }
        public string UserManualUri { get; set; }
        public string TechDocumentUri { get; set; }
        public Guid ProductCategoryId { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, SuccessServiceResponse<Guid>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                await _productRepository.UpdateAsync(product);
                return new SuccessServiceResponse<Guid>(product.Id, Messages.ProductUpdaded);
            }
        }
    }
}
