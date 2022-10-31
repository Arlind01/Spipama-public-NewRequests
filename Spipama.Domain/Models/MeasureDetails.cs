using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class MeasureDetails :BaseModel
    {
        public Guid MeasureId { get; set; }
        public Measure Measure { get; set; }
        public decimal? BudgetSpent { get; set; }
        public Guid? StrategySourceOfFundingId { get; set; }
        public StrategySourceOfFunding StrategySourceOfFunding { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
    }
}
