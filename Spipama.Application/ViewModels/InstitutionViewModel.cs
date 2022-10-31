using SPIPAMA.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.ViewModels
{
    public class InstitutionViewModel : BaseModel
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
     
    }
}
