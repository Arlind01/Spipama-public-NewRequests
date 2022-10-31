using Spipama.Application.Pagination;
using Spipama.Application.ViewModels;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Interfaces
{
    public interface IFileManagementService
    {
        Task<FileManagementViewModel> GetFileManagementById(Guid fileId);
        Task<FileManagementDTO> GetFilesManagement(PaginationFilter paginationFilter, Guid CategoryId);
        Task<List<FileCategory>> GetFileCategory();
    }
}
