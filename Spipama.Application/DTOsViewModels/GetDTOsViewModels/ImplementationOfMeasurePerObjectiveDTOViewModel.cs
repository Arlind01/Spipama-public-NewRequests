using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.DTOsViewModels.GetDTOsViewModels
{
    public class ImplementationOfMeasurePerObjectiveDTOViewModel 
    {
        public Guid ActionPlanId { get; set; }
        public string ObjectiveIdentifier { get; set; } 
        public int NumberOfMeasures { get; set; }
        public int NumberOfImplementedMeasures { get; set; }
    }
}
