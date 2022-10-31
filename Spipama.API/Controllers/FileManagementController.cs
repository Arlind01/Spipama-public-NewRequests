using Microsoft.AspNetCore.Mvc;
using Spipama.API.Errors;
using Spipama.API.Helpers;
using Spipama.Application.Interfaces;
using Spipama.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spipama.API.Controllers
{
    public class FileManagementController : BaseApiController
    {
        private readonly IFileManagementService fileManagementService;
        private readonly IPaginationService paginationService;

        public FileManagementController(IFileManagementService fileManagementService, IPaginationService paginationService)
        {
            this.fileManagementService = fileManagementService;
            this.paginationService = paginationService;
        }

        [HttpGet("getFileManagementById/{fileId}")]
        public async Task<IActionResult> GetFileManagementById(Guid fileId)
        {
            try
            {
                var files = await fileManagementService.GetFileManagementById(fileId);
                return Ok(files);
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse(404, "Dosja nuk u gjet!"));
            }
        }

        [HttpGet("getFilesManagement")]
        public async Task<IActionResult> GetFileManagement([FromQuery] PaginationFilter filter, Guid CategoryId)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await fileManagementService.GetFilesManagement(validFilter, CategoryId);
            var totalRecords = pagedData.TotalRecords;
            var pagedReponse = Pagination.CreatePagedReponse(pagedData.FileManagement, validFilter, totalRecords, this.paginationService, route);
            return Ok(pagedReponse);
        }

        [HttpGet("getFilesCategory")]
        public async Task<IActionResult> GetFilesCategory()
        {
            try
            {
                var result = await fileManagementService.GetFileCategory();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400, "Nuk u gjet lista!"));
            }
        }
    }
}
