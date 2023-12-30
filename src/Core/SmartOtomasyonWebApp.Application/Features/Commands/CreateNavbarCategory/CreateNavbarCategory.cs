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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateNavbarCategory
{
    public class CreateNavbarCategoryCommand :IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public Guid NavbarId { get; set; }

        public class CreateNavbarCategoryCommandHandler : IRequestHandler<CreateNavbarCategoryCommand, ServiceResponse<Guid>>
        {
            INavbarCategoryRepository _navbarCategoryRepository;
            private readonly IMapper _mapper;
            public CreateNavbarCategoryCommandHandler(INavbarCategoryRepository navbarCategoryRepository, IMapper mapper)
            {
                _navbarCategoryRepository = navbarCategoryRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateNavbarCategoryCommand request, CancellationToken cancellationToken)
            {
                var navbarCategory = _mapper.Map<NavbarCategory>(request);
                await _navbarCategoryRepository.AddAsync(navbarCategory);
                return new ServiceResponse<Guid>(navbarCategory.Id);
            }
        }
    }
}
