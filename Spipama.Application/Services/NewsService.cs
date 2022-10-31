using AutoMapper;
using Microsoft.AspNetCore.Http;
using Spipama.Application.Interfaces;
using Spipama.Application.Pagination;
using Spipama.Application.ViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;

        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public async Task<NewsDetailsDTO> GetNews(PaginationFilter paginationFilter)
        {
            var result = this.mapper.Map<PaginationFilterDTO>(paginationFilter);
            return (await newsRepository.GetNews(result));
        }

        public async Task<NewsViewModel> GetNewsById(Guid newsId)
        {
            var result = await this.newsRepository.GetNewsById(newsId);
            return this.mapper.Map<NewsViewModel>(result);
        }
    }
}
