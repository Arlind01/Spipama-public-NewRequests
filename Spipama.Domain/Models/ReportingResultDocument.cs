using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class ReportingResultDocument : BaseModel
    {
        public Guid ReportingResultId { get;set; }
        public ReportingResult ReportingResult { get; set; }
        public string FileRef { get; set; }
        public string FileName { get; set; }
    }
}
