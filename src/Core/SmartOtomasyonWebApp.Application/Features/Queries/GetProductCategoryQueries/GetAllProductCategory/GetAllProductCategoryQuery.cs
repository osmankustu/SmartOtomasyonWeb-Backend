using MediatR;
using SmartOtomasyonWebApp.Application.Dto.ProductCategory;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetProductCategoryQueries.GetAllProductCategory
{
    public class GetAllProductCategoryQuery : IRequest<ServiceResponse<List<ProductCategoryView>>>
    {

    }
}
