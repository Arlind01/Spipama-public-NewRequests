using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Spipama.API.Errors;
using Spipama.Application.Interfaces;
using Spipama.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spipama.API.Controllers
{
    public class ContactController : BaseApiController
    {
        private readonly IContactService contactService;
        private readonly IOverviewService overviewService;

        public ContactController(IContactService contactService, IOverviewService overviewService)
        {
            this.contactService = contactService;
            this.overviewService = overviewService;
        }

        [HttpPost("sendEmail")]
        public async Task<IActionResult> SendEmail ( SendEmailViewModel obj)
        {
            if (obj != null)
            {
                try
                {
                    var reportUser = await contactService.SendEmail(obj);
                    return Ok(reportUser);
                }
                catch (Exception ex)
                {
                    return BadRequest(new ApiResponse(400, "Email nuk është dërguar!"));
                }
            }


            return BadRequest(new ApiResponse(400, "Email nuk është dërguar!"));
        }
    }
}
