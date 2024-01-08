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

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,ServiceResponse<Guid>> 
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                await _productRepository.DeleteAsync(product);
                return new ServiceResponse<Guid>(product.Id,Messages.ProductlDeleted);
            }
        }
    }
}
