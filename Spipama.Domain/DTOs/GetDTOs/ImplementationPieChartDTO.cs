using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.DTOs.GetDTOs
{
    public class ImplementationPieChartDTO
    {
        public Guid ActionPlanId { get; set; }
        public int Implemented { get; set; }
        public int NotImplemented { get; set; }
        public byte[] ImpDoc { get; set; }
        public byte[] NotImpDoc { get; set; } 
    }
}
