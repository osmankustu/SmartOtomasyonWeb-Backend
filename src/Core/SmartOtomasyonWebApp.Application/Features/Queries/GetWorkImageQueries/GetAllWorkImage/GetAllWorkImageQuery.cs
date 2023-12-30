using MediatR;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetAllWorkImage
{
    public class GetAllWorkImageQuery: IRequest<ServiceResponse<List<WorkImageView>>>
    {
    }
}
