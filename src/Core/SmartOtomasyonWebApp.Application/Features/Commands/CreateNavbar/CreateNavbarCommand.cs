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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateNavbar
{
    public class CreateNavbarCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }


        public class CreateNavbarCommandHandler : IRequestHandler<CreateNavbarCommand, ServiceResponse<Guid>>
        {
            INavbarRepository _navbarRepository;
            private readonly IMapper _mapper;
            
            public CreateNavbarCommandHandler( INavbarRepository navbarRepository, IMapper mapper)
            {
                _navbarRepository = navbarRepository ?? throw new ArgumentNullException(nameof(navbarRepository));
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateNavbarCommand request, CancellationToken cancellationToken)
            {
                var navbar = _mapper.Map<Navbar>(request);
                await _navbarRepository.AddAsync(navbar);
                return new ServiceResponse<Guid>(navbar.Id);
            }
        }
    }
}
