using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Domain.Models
{
   public class FileManagement : BaseModel
    {
        public Guid CategoryId { get; set; }

        public string FileName { get; set; }

        public string FileLocation { get; set; }
    }
}
