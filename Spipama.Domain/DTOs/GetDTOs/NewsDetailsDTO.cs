using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.DTOs.GetDTOs
{
   public class NewsDetailsDTO
    {
        public NewsDetailsDTO(int totalRecords, List<News> news)
        {
            this.TotalRecords = totalRecords;
            this.News = news;

        }
        public int TotalRecords { get; set; }
        public List<News> News { get; set; }
    }
}
