using Microsoft.AspNetCore.Http;
using Spipama.Application.Pagination;
using Spipama.Application.ViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Interfaces
{
   public interface INewsService
    {
        Task<NewsViewModel> GetNewsById(Guid newsId);
        Task<NewsDetailsDTO> GetNews(PaginationFilter paginationFilter);
    }
}
