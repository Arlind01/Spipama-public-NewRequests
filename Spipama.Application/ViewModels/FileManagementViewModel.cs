using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.ViewModels
{
    public class FileManagementViewModel
    {
        public Guid CategoryId { get; set; }

        public string FileName { get; set; }

        public string FileLocation { get; set; }
    }
}
