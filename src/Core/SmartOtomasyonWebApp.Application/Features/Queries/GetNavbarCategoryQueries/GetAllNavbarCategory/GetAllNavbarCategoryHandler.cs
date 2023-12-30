using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.NavbarCategory;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetNavbarCategoryQueries.GetAllNavbarCategory
{
    public class GetAllNavbarCategoryHandler : IRequestHandler<GetAllNavbarCategoryQuery, ServiceResponse<List<NavbarCategoryView>>>
    {
        INavbarCategoryRepository _navbarCategoryRepository;
        private readonly IMapper _mapper;
        public GetAllNavbarCategoryHandler(INavbarCategoryRepository navbarCategoryRepository, IMapper mapper)
        {
            _navbarCategoryRepository = navbarCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<NavbarCategoryView>>> Handle(GetAllNavbarCategoryQuery request, CancellationToken cancellationToken)
        {
            var list = await _navbarCategoryRepository.GetAllAsync();
            var viewModel = _mapper.Map<List<NavbarCategoryView>>(list);
            return new ServiceResponse<List<NavbarCategoryView>>(viewModel);
        }
    }
}
