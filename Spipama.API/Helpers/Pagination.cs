using Spipama.Application.Interfaces;
using Spipama.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spipama.API.Helpers
{
    public class Pagination
    {
        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, PaginationFilter validFilter, int totalRecords, IPaginationService uriService, string route)
        {
            var respose = new PagedResponse<List<T>>(validFilter.PageNumber, validFilter.PageSize, pagedData,pagedData.Count());
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPage(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPage(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            respose.FirstPage = uriService.GetPage(new PaginationFilter(1, validFilter.PageSize), route);
            respose.LastPage = uriService.GetPage(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
