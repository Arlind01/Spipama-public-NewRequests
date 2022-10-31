using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.DTOs.GetDTOs
{
    public class PaginationFilterDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SearchString { get; set; }

        public PaginationFilterDTO()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
            this.Institution = "";
        }
        public PaginationFilterDTO(int pageNumber, int pageSize, string institution)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 50 ? 50 : pageSize;
            this.Institution = institution;
        }

        public PaginationFilterDTO(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 50 ? 50 : pageSize;
        }

        public PaginationFilterDTO(int pageNumber, int pageSize, string institution, DateTime startDate, DateTime endDate,string searchString)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 50 ? 50 : pageSize;
            this.Institution = institution;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SearchString = searchString;
        }
    }
}
