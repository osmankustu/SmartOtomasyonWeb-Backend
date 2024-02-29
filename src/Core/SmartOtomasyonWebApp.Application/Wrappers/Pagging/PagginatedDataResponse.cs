using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Wrappers.Pagging
{
    public class PagginatedDataResponse<T> : PageResponse
    {
        public PagginatedDataResponse(T data,int pageIndex,int pageSize,int totalCount,int pageCount)
            :base(pageIndex,pageSize,totalCount,pageCount)
        {
            Data = data;
        }

        public T Data { get; set; }



    }
}
