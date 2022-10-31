using Microsoft.AspNetCore.Http;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Interfaces
{
   public interface INewsRepository
    {
        Task<News> GetNewsById(Guid newsId);
        Task<NewsDetailsDTO> GetNews(PaginationFilterDTO paginationFilter);

    }
}
