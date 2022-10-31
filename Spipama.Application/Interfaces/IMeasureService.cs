using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Interfaces
{
    public interface IMeasureService
    {
        Task<List<MeasureWithDetailsViewModel>> GetMeasureDetails(Guid objectiveSpecificId);
    }
}
