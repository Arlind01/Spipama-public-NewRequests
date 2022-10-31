using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spipama.Domain.Context;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly SpipamaPublicWebDbContext context;
        public readonly IHttpContextAccessor httpContextAccessor;

        public NewsRepository(SpipamaPublicWebDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<NewsDetailsDTO> GetNews(PaginationFilterDTO paginationFilter)
        {
           var news = await context.News
                .Where(i => i.IsDeleted == false)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize).ToListAsync();

            var request = httpContextAccessor.HttpContext.Request;

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            var config = builder.Build();

            foreach (var data in news)
            {
                var domain = config["Domain:Host"];
                if (data.ImageUrl != null)
                {
                    data.ImageUrl = domain + data.ImageUrl;
                }
                else
                {
                    //var domain = $"{request.Scheme}://{request.Host}";
                    data.ImageUrl = domain + "\\UploadedFiles\\News\\defaultNewsImg.png";
                }
            }
            return new NewsDetailsDTO(context.News.Count(), news);

        }

        public async Task<News> GetNewsById(Guid newsId)
        {
            var news =  await context.News.Where(x => x.Id == newsId).SingleAsync();

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var domain = config["Domain:Host"];
            if (news.ImageUrl != null)
            {
                news.ImageUrl = domain + news.ImageUrl;
            }
            return news;
        }
    }
}
