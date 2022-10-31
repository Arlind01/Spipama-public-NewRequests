using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Interfaces
{
    public interface IOverviewRepository
    {
        Task<IEnumerable<ActionPlan>> GetActionPlans();
        Task<IEnumerable<ImplementationOfMeasurePerInstitutionDTO>> GetOverviewOfImplementationMeasurePerInstitution(Guid actionPlanId);
        Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTO>> GetOverviewOfImplementationMeasurePerPerObjectiveStrategic(Guid actionPlanId);
        Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTO>> GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(Guid actionPlanId);
        Task<ImplementationPieChartDTO> GetOverviewOfImplementationOfIndicators(Guid actionPlanId);
        Task<ImplementationPieChartDTO> GetOverviewOfImplementationOfMeasures(Guid actionPlanId);
    }
}
