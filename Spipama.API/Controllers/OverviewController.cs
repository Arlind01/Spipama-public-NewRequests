using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spipama.Application.Interfaces;
using Spipama.Domain.DTOs.GetDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Spipama.Application.ViewModels;
using System.Linq;
using System.Security.Claims;
using Spipama.Application.DTOsViewModels.GetDTOsViewModels;
using Spipama.API.Errors;

namespace Spipama.API.Controllers
{
    public class OverviewController : BaseApiController
    {
        private readonly IOverviewService overviewService;

        public OverviewController(IOverviewService overviewService)
        {
            this.overviewService = overviewService;
        }

        [HttpGet("getActionPlans")]
        public async Task<IActionResult> GetActionPlans()
        {
            try
            {
                var result = await overviewService.GetActionPlans();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Plani i veprimit nuk u gjet!"));
            }
        }

        [HttpGet("getOverviewOfImplementationMeasurePerInstitution/{actionPlanId}")]
        public async Task<IActionResult> GetOverviewOfImplementationMeasurePerInstitution(Guid actionPlanId)
        {
            try
            {
                var results = await overviewService.GetOverviewOfImplementationMeasurePerInstitution(actionPlanId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Pasqyra e aktivieteve nuk u gjet!"));
            }
        }

        [HttpGet("getOverviewOfImplementationOfMeasurePerObjectiveStrategic/{actionPlanId}")]
        public async Task<IActionResult> GetOverviewOfImplementationOfMeasurePerObjectiveStrategic(Guid actionPlanId)
        {
            try
            {
                var results = await overviewService.GetOverviewOfImplementationMeasurePerObjectiveStrategic(actionPlanId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Pasqyra e aktivieteve nuk u gjet!"));
            }
        }

        [HttpGet("getOverviewOfImplementationOfIndicators/{actionPlanId}")]
        public async Task<IActionResult> GetOverviewOfImplementationOfIndicators(Guid actionPlanId)
        {
            try
            {
                var results = await overviewService.GetOverviewOfImplementationOfIndicators(actionPlanId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Pasqyra e aktivieteve nuk u gjet!"));
            }
        }

        [HttpGet("getOverviewOfImplementationOfMeasurePerObjectiveSpecific/{actionPlanId}")]
        public async Task<IActionResult> GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(Guid actionPlanId)
        {
            try
            {
                var results = await overviewService.GetOverviewOfImplementationOfMeasurePerObjectiveSpecific(actionPlanId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Pasqyra e aktivieteve nuk u gjet!"));
            }
        }

        [HttpGet("getOverviewOfImplementationOfMeasures/{actionPlanId}")]
        public async Task<IActionResult> GetOverviewOfImplementationOfMeasures(Guid actionPlanId)
        {
            try
            {
                var results = await overviewService.GetOverviewOfImplementationOfMeasures(actionPlanId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Pasqyra e aktivieteve nuk u gjet!"));
            }

        }
        
        [HttpGet("getStatisticOfPlans/{actionPlanId}")]
        public async Task<IActionResult> GetStatisticOfPlans(Guid actionPlanId)
        {
            try
            {
                var results = await overviewService.GetStatisticOfPlans(actionPlanId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Statistika nuk u gjet!"));
            }

        }
    }
}
