using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
    public class Notification : BaseModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public int Type { get; set; }
        public Guid? MeasureId { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public bool Acknowledge { get; set; }
        public bool IsSent { get; set; }
    }
}
