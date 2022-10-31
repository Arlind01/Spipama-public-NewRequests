using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Pagination
{
   public class PagedResponse<T>
    {
        public PagedResponse(int pageNumber, int pageSize, T data,int itemCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            ItemCount = itemCount;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public T Data { get; set; }
    }
}
