using Microsoft.AspNetCore.Mvc;
using Spipama.API.Errors;
using Spipama.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spipama.API.Controllers
{
    public class SettingsController : BaseApiController
    {
        private readonly ISettingsService settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        [HttpGet("downloadDoc")]
        public IActionResult DownloadDoc([FromQuery] string path)
        {
            var content = settingsService.DownloadDoc(path);
            return File(content.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        [HttpGet("downloadStaticDoc")]
        public IActionResult DownloadStaticDoc([FromQuery] string path)
        {
            var content = settingsService.DownloadStaticDoc(path);
            return File(content.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        } 

        [HttpGet("getGVRAPConclusions")]
        public IActionResult GetGVRAPConclusions()
        {
            try
            {
                var gvrap = settingsService.GetGVRAPConclusions();
                return Ok(gvrap);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400, "Dokumentet nuk u gjeten!"));
            }
        }

        [HttpGet("getKMRAPConclusions")]
        public IActionResult GetKMRAPConclusions()
        {
            try
            {
                var kmrap = settingsService.GetKMRAPConclusions();
                return Ok(kmrap);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400, "Dokumentet nuk u gjeten!"));
            }
        }

        [HttpGet("getRAPStrategies")]
        public IActionResult GetRAPStrategies()
        {
            try
            {
                var rapStrategies = settingsService.GetRAPStrategies();
                return Ok(rapStrategies);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400, "Dokumentet nuk u gjeten!"));
            }
        }

        [HttpGet("getRAPImplementationReports")]
        public IActionResult GetRAPImplementationReports()
        {
            try
            {
                var implementationReports = settingsService.GetRAPImplementationReports();
                return Ok(implementationReports);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400, "Dokumentet nuk u gjeten!"));
            }
        }

        [HttpGet("publicCodes/{language}")]
        public IActionResult GetPublicCodes(string language)
        {
            try
            {
                var publicCodes = settingsService.GetPublicCodes(language);
                return Ok(publicCodes);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400, "Codet nuk u gjeten"));
            }
        }

        [HttpGet("getGovernmentProgram")]
        public IActionResult GetGovernmentProgram() 
        {
            try
            {
                var govProgram = settingsService.GetGovernmentProgram();
                return Ok(govProgram);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, "Dokumentet nuk u gjeten!"));
            }
        }
    }
}
