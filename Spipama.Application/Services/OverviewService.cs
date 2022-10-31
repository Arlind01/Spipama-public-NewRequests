using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.Application.Interfaces;
using Spipama.Application.ViewModels;
using Spipama.Domain.Context;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Services
{
    public class OverviewService : IOverviewService
    {
        private readonly IOverviewRepository overviewRepository;
        private readonly IMapper mapper;
        private readonly SpipamaPublicWebDbContext context;

        public OverviewService(IOverviewRepository overviewRepository, IMapper mapper, SpipamaPublicWebDbContext context)
        {
            this.overviewRepository = overviewRepository;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<IEnumerable<ActionPlanViewModel>> GetActionPlans()
        {
            return mapper.Map<IEnumerable<ActionPlanViewModel>>(await overviewRepository.GetActionPlans());
        }

        public async Task<IEnumerable<ImplementationOfMeasurePerInstitutionDTOViewModel>> GetOverviewOfImplementationMeasurePerInstitution(Guid actionPlanId)
        {
            var result = await overviewRepository.GetOverviewOfImplementationMeasurePerInstitution(actionPlanId);
            return mapper.Map<IEnumerable<ImplementationOfMeasurePerInstitutionDTOViewModel>>(result);
        }

        public async Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTOViewModel>> GetOverviewOfImplementationMeasurePerObjectiveStrategic(Guid actionPlanId)
        {
            var result = await overviewRepository.GetOverviewOfImplementationMeasurePerPerObjectiveStrategic(actionPlanId);
            return mapper.Map<IEnumerable<ImplementationOfMeasurePerObjectiveDTOViewModel>>(result);
        }

        public async Task<ImplementationPieChartDTOViewModel> GetOverviewOfImplementationOfIndicators(Guid actionPlanId)
        {
            var result = await overviewRepository.GetOverviewOfImplementationOfIndicators(actionPlanId);
            return mapper.Map<ImplementationPieChartDTOViewModel>(result);
        }

        public async Task<IEnumerable<ImplementationOfMeasurePerObjectiveDTOViewModel>> GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(Guid actionPlanId)
        {
            var result = await overviewRepository.GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(actionPlanId);
            return mapper.Map<IEnumerable<ImplementationOfMeasurePerObjectiveDTOViewModel>>(result);
        }

        public async Task<ImplementationPieChartDTOViewModel> GetOverviewOfImplementationOfMeasures(Guid actionPlanId)
        {
            var result = await overviewRepository.GetOverviewOfImplementationOfMeasures(actionPlanId);
            return mapper.Map<ImplementationPieChartDTOViewModel>(result);
        }

        public async Task<StatisticsOfPlanDTOViewModel> GetStatisticOfPlans(Guid actionPlanId)
        {
            var objStra = await context.ObjectiveStrategics.Where(x => x.ActionPlanId == actionPlanId).ToListAsync();
            List<ObjectiveSpecific> objSpe = new List<ObjectiveSpecific>();
            foreach(var obj in objStra)
            {
                objSpe.AddRange(await context.ObjectiveSpecifics.Where(x => x.ObjectiveStrategicId == obj.Id).ToListAsync()); 
            }

            int allMeasures = 0;
            int implementedMeasures = 0;

            foreach (var obj in objSpe)
            {
                allMeasures += context.Measures.Where(x => x.ObjectiveSpecificId == obj.Id).Count();
                implementedMeasures += context.Measures.Where(x => x.ObjectiveSpecificId == obj.Id && x.Status == 1).Count();

            }

            StatisticsOfPlanDTOViewModel statisticsOfPlan = new StatisticsOfPlanDTOViewModel
            {
                AllActionPlans = await context.ActionPlans.CountAsync(),
                ActiveActionPlans = await context.ActionPlans.Where(x => x.Status == 1).CountAsync(),
                AllMeasures = allMeasures,
                ImplementedMeasures = implementedMeasures
            };

            return statisticsOfPlan;
        }
    }
}
