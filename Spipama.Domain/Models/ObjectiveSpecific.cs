using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class ObjectiveSpecific : BaseModel
    {
        public int Identifier { get; set; }
        public Guid ObjectiveStrategicId { get; set; }
        public ObjectiveStrategic ObjectiveStrategic { get; set; }
        public string Name { get; set; }
        public decimal? BudgetTotal { get; set; }
        public decimal? BudgetCapital { get; set; }
        public decimal? BudgetCost { get; set; }

    }
}