using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class StrategySourceOfFunding : BaseModel
    {
        public Guid ActionPlanId { get; set; }
        public ActionPlan ActionPlan { get; set; }
        public string Name { get; set; }
    }
}
