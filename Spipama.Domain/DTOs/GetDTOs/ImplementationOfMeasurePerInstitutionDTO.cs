using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.DTOs.GetDTOs
{
    public class ImplementationOfMeasurePerInstitutionDTO
    {
        public Guid ActionPlanId { get; set; }
        public InstitutionDTO Institution { get; set; }
        public int NumberOfMeasures { get; set; }
        public int NumberOfImplementedMeasures { get; set; }
    }
}
