using AutoMapper;
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
    public class FileManagementService : IFileManagementService
    {
        private readonly IFileManagementRepository fileManagementRepository;
        private readonly IMapper mapper;

        public FileManagementService(IFileManagementRepository fileManagementRepository, IMapper mapper)
        {
            this.fileManagementRepository = fileManagementRepository;
            this.mapper = mapper;
        }

        public async Task<FileManagementViewModel> GetFileManagementById(Guid fileId)
        {
            var result = await this.fileManagementRepository.GetFileManagementById(fileId);
            return this.mapper.Map<FileManagementViewModel>(result);
        }

        public async Task<FileManagementDTO> GetFilesManagement(PaginationFilter paginationFilter, Guid CategoryId)
        {
            var result = this.mapper.Map<PaginationFilterDTO>(paginationFilter);
            return (await fileManagementRepository.GetFilesManagement(result, CategoryId));
        }

        public async Task<List<FileCategory>> GetFileCategory()
        {
            var result = await fileManagementRepository.GetFileCategoryListAsync();
            return result;
        }
    }
}
