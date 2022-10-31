using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spipama.Domain.Context;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly SpipamaPublicWebDbContext context;
        private readonly IMapper mapper;

        public MeasureRepository(SpipamaPublicWebDbContext context,
                                IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<MeasureWithDetailsDTO>> GetMeasureDetails(Guid objectiveSpecificId) 
        {
            List<MeasureWithDetailsDTO> measureWithDetailsDTO = new List<MeasureWithDetailsDTO>();
            List<Measure> measures = await context.Measures.Where(x => x.ObjectiveSpecificId == objectiveSpecificId && x.IsDeleted == false).Include(x => x.ResponsibleInstitution).OrderBy(x => x.CreatedOn).ToListAsync();
            measureWithDetailsDTO = mapper.Map<List<MeasureWithDetailsDTO>>(measures);

            foreach (var measureWithDetails in measureWithDetailsDTO)
            {
                List<MeasureDetails> getMeasureDetails = context.MeasureDetails.Where(x => x.MeasureId == measureWithDetails.Id && x.IsDeleted == false).Include(x => x.StrategySourceOfFunding).OrderBy(x => x.CreatedOn).ToList();
                getMeasureDetails.ForEach(x => x.StrategySourceOfFunding = context.StrategySourceOfFundings.Where(y => y.Id == x.StrategySourceOfFundingId && x.IsDeleted == false).FirstOrDefault());
                measureWithDetails.MeasureDetails = mapper.Map<List<MeasureDetailsDTO>>(getMeasureDetails);
            }

            return measureWithDetailsDTO;
        }
    }
}
