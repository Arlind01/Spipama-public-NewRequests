using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class IndicatorSpecificDetails : BaseModel
    {
        public Guid? IndicatorSpecificId { get; set; }
        public IndicatorSpecific IndicatorSpecific { get; set; }
        public int Year { get; set; }
        public int Indicator { get; set; }
        public int? IndicatorAchieved { get; set; }
        //public string Result { get; set; }
    }
}
