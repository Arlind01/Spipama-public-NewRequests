using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.DTOs.GetDTOs
{
  public class FileManagementDTO
    {
        public FileManagementDTO(int totalRecords, List<FileManagement> fileManagements)
        {
            this.TotalRecords = totalRecords;
            this.FileManagement = fileManagements;

        }
        public int TotalRecords { get; set; }
        public List<FileManagement> FileManagement { get; set; }
    }
}
