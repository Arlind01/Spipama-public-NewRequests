using Spipama.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Interfaces
{
   public interface IPaginationService
    {
        public Uri GetPage(PaginationFilter filter, string route);
    }
}
