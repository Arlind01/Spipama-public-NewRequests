using SPIPAMA.Domain.BaseModel; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models 
{
    public class ActionPlan : BaseModel
    {
        public string Name { get; set; }
        public string StrategyName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int ActiveYear { get; set; }
        public int Status { get; set; }
        public decimal? BudgetTotal { get; set; }
        public decimal? BudgetCapital { get; set; }
        public decimal? BudgetCost { get; set; }
        public string? FileRef { get; set; }
        public string? FileName { get; set; }
        public string? IndicatorFileRef { get; set; }
        public string? IndicatorFileName { get; set; }
    }
}
