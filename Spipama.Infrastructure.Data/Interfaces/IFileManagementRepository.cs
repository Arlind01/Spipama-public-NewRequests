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
   public interface IFileManagementRepository
    {
        Task<FileManagement> GetFileManagementById(Guid fileId);
        Task<FileManagementDTO> GetFilesManagement(PaginationFilterDTO paginationFilter, Guid CategoryId);
        Task<List<FileCategory>> GetFileCategoryListAsync();
    }
}
