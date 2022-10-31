using Microsoft.AspNetCore.Mvc;
using Spipama.API.Errors;
using Spipama.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spipama.API.Controllers
{
    public class MeasureController : BaseApiController
    {
        private readonly IMeasureService measureService;

        public MeasureController(IMeasureService measureService)
        {
            this.measureService = measureService;
        }

        [HttpGet("getMeasureDetails/{objectiveSpecificId}")]
        public async Task<IActionResult> GetMeasureDetails(Guid objectiveSpecificId) 
        {
            try
            {
                var measure = await measureService.GetMeasureDetails(objectiveSpecificId);
                return Ok(measure);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Masa nuk u gjet!"));
            }
        }
    }
}
