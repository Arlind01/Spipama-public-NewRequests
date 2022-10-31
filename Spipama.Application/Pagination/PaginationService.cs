using Microsoft.AspNetCore.WebUtilities;
using Spipama.Application.Interfaces;
using Spipama.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Services
{
    public class PaginationService : IPaginationService
    {
        public Uri GetPage(PaginationFilter filter, string route)
        {
            var _enpointPage = new Uri("https://localhost:4200/home/log/");
            var modifiedPage = QueryHelpers.AddQueryString(_enpointPage.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedPage = QueryHelpers.AddQueryString(modifiedPage, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedPage);
        }
    }
}
