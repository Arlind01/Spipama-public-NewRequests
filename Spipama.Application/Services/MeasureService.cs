using AutoMapper;
using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.Application.Interfaces;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Application.Services
{
    public class MeasureService : IMeasureService
    {

        private readonly IMeasureRepository measureRepository;
        private readonly IMapper mapper;

        public MeasureService(IMeasureRepository measureRepository,
                             IMapper mapper)
        {
            this.measureRepository = measureRepository;
            this.mapper = mapper;
        }

        public async Task<List<MeasureWithDetailsViewModel>> GetMeasureDetails(Guid objectiveSpecificId)
        {
            var result = await measureRepository.GetMeasureDetails(objectiveSpecificId);
            return mapper.Map<List<MeasureWithDetailsViewModel>>(result);
        }
    }
}
