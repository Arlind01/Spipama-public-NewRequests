using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.DTOs.GetDTOs
{
    public class MeasureDetailsDTO
    {
        public Guid? Id { get; set; }
        public Guid? MeasureId { get; set; }
        public int? Year { get; set; }
        public decimal? Budget { get; set; }
        public decimal? BudgetSpent { get; set; } 
        public Guid? StrategySourceOfFundingId { get; set; }
        public StrategySourceOfFunding StrategySourceOfFunding { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
