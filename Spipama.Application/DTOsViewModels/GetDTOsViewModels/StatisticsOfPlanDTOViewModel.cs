using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.DTOsViewModels.GetDTOsViewModels
{
    public class StatisticsOfPlanDTOViewModel
    {
        public int AllActionPlans { get; set; }
        public int ActiveActionPlans { get; set; }
        public int AllMeasures { get; set; }
        public int ImplementedMeasures { get; set; }
    }
}
