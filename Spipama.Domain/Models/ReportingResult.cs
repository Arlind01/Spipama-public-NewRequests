using Microsoft.AspNetCore.Http;
using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class ReportingResult : BaseModel
    {
        public int TypeId { get; set; }
        public Guid? IndicatorStrategicId { get; set; }
        public IndicatorStrategic IndicatorStrategic { get; set; }
        public Guid? IndicatorSpecificId { get; set; }
        public IndicatorSpecific IndicatorSpecific { get; set; }
        public Guid? MeasureId { get; set; }
        public Measure Measure { get; set; }
        public string Reason { get; set; }
        public Guid UserId { get; set; }
    }
}
