using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Products.Domain.Common.Utils;
using Products.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Services
{
    public class Pagination : IPagination
    {
     private IHttpContextAccessor _accessor;

    public Pagination(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public void Paginate(long itemsCount, PaginationParams @params)
    {
        PaginationMetaData metaData = new PaginationMetaData();
        metaData.CurrentPage = @params.PageNumber;
        metaData.TotalItems = int.Parse(itemsCount.ToString());
        metaData.PageSize = @params.PageSize;

        metaData.TotalPages = (int)Math.Ceiling((double)itemsCount) / (@params.PageSize);
        if ((int)Math.Ceiling((double)itemsCount) % (@params.PageSize) > 0)
        {
            metaData.TotalPages += 1;
        }
        metaData.HasPrevious = metaData.CurrentPage > 1;
        metaData.HasNext = metaData.CurrentPage < metaData.TotalPages;

        string Convert = JsonConvert.SerializeObject(metaData);
        _accessor.HttpContext!.Response.Headers.Add("x-pagination", Convert);
    }
    }
}
