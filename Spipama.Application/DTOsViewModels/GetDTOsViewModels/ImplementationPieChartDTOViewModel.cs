using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.DTOsViewModels.GetDTOsViewModels
{
    public class ImplementationPieChartDTOViewModel
    {
        public Guid ActionPlanId { get; set; }
        public int Implemented { get; set; } 
        public int NotImplemented { get; set; }
        public byte[] ImpDoc { get; set; }
        public byte[] NotImpDoc { get; set; }
    }
}
