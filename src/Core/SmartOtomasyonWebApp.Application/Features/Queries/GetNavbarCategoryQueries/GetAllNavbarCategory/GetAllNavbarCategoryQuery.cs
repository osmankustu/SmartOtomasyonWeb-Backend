using MediatR;
using SmartOtomasyonWebApp.Application.Dto.NavbarCategory;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetNavbarCategoryQueries.GetAllNavbarCategory
{
    public class GetAllNavbarCategoryQuery :IRequest<ServiceResponse<List<NavbarCategoryView>>>
    {
    }
}
