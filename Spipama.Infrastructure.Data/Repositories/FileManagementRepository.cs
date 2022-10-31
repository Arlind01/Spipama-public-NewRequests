using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spipama.Domain.Context;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Helpers.Models;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class FileManagementRepository : IFileManagementRepository
    {
        private readonly SpipamaPublicWebDbContext context;
        public readonly IHttpContextAccessor httpContextAccessor;
        private readonly IGenericRepository<FileManagement> genericRepository;


        public FileManagementRepository(SpipamaPublicWebDbContext context, IHttpContextAccessor httpContextAccessor, IGenericRepository<FileManagement> genericRepository)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.genericRepository = genericRepository;
        }

        public async Task<List<FileCategory>> GetFileCategoryListAsync()
        {
            var categories = await context.FileCategories.ToListAsync();
            return categories;
        }


        public async Task<FileManagement> GetFileManagementById(Guid fileId)
        {
            var files = await context.FileManagements.Where(x => x.Id == fileId && x.IsDeleted == false).SingleAsync();

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var domain = config["Domain:Host"];

            files.FileLocation = domain + files.FileLocation;

            return files;
        }

        public async Task<FileManagementDTO> GetFilesManagement(PaginationFilterDTO paginationFilter, Guid CategoryId)
        {
            var files = await context.FileManagements
                .Where(i => i.IsDeleted == false && i.CategoryId == CategoryId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize).ToListAsync();

            var filesCount = await context.FileManagements
                .Where(i => i.IsDeleted == false && i.CategoryId == CategoryId).CountAsync();

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var domain = config["Domain:Host"];

            foreach (var data in files)
            {
                if (data.FileName != null)
                {
                    data.FileLocation = domain + data.FileLocation;
                }
                else
                {
                    //var domain = $"{request.Scheme}://{request.Host}";
                    data.FileLocation = "";
                }
            }
            return new FileManagementDTO(filesCount, files);

        }
    }
}
