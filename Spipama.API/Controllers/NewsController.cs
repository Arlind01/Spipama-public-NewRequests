using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Spipama.API.Errors;
using Spipama.API.Helpers;
using Spipama.Application.Interfaces;
using Spipama.Application.Pagination;
using Spipama.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spipama.API.Controllers
{

    public class NewsController : BaseApiController
    {

        private readonly INewsService newsService;
        private readonly IPaginationService paginationService;

        public NewsController(INewsService newsService, IPaginationService paginationService)
        {
            this.newsService = newsService;
            this.paginationService = paginationService;
        }
        
        [HttpGet("getNewsById/{newsId}")]
        public async Task<IActionResult> GetNewsById(Guid newsId)
        {
            try
            {
                var news = await newsService.GetNewsById(newsId);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse(404, "Lajmi nuk u gjet!"));
            }
        }

        [HttpGet("getNews")]
        public async Task<IActionResult> GetNews([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await newsService.GetNews(validFilter);
            var totalRecords = pagedData.TotalRecords;
            var pagedReponse = Pagination.CreatePagedReponse(pagedData.News, validFilter, totalRecords, this.paginationService, route);
            return Ok(pagedReponse);
        }
    }
}
