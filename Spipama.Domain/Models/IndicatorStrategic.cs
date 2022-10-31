using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class IndicatorStrategic : BaseModel
    {
        public Guid ObjectiveStrategicId { get; set; }
        public ObjectiveStrategic ObjectiveStrategic { get; set; }
        public int Identifier { get; set; }
        public string Name { get; set; }
        public int Base { get; set; }
        public int InputType { get; set; }
        public int IndicatorTemp { get; set; }
        public int? IndicatorTempAchieved { get; set; }
        public int IndicatorFinal { get; set; }
        public int? IndicatorFinalAchieved { get; set; }
        public string Result { get; set; }
        public int IndicatorStatusId { get; set; }
        public IndicatorStatus IndicatorStatus { get; set; }
        public Guid ResponsibleInstitutionId { get; set; }
        public Institution ResponsibleInstitution { get; set; }
    }
}
