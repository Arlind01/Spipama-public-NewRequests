using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Interfaces
{
    public interface IOverviewService
    {

        Task<IEnumerable<ActionPlanViewModel>> GetActionPlans();
        Task<IEnumerable<ImplementationOfMeasurePerInstitutionDTOViewModel>> GetOverviewOfImplementationMeasurePerInstitution(Guid actionPlanId);
        Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTOViewModel>> GetOverviewOfImplementationMeasurePerObjectiveStrategic(Guid actionPlanId);
        Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTOViewModel>> GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(Guid actionPlanId);
        Task<ImplementationPieChartDTOViewModel> GetOverviewOfImplementationOfIndicators(Guid actionPlanId);
        Task<ImplementationPieChartDTOViewModel> GetOverviewOfImplementationOfMeasures(Guid actionPlanId);
        Task<StatisticsOfPlanDTOViewModel> GetStatisticOfPlans(Guid actionPlanId); 
    }
}
