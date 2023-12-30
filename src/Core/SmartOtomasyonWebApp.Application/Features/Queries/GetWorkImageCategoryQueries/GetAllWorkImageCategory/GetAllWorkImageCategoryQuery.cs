using MediatR;
using SmartOtomasyonWebApp.Application.Dto.WorkImageCategory;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries.GetAllWorkImageCategory
{
    public class GetAllWorkImageCategoryQuery : IRequest<ServiceResponse<List<WorkImageCategoryView>>>
    {
    }
}
