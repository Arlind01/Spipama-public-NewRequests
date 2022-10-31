using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class MeasureResponsibleInstitution : BaseModel
    {
        public Guid MeasureId { get; set; }
        public Measure Measure { get; set; }
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; }
    }
}
