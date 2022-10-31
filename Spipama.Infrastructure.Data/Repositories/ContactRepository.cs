using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spipama.Domain.Context;
using Spipama.Domain.DTOs.GetDTOs;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Helpers;
using Spipama.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly SpipamaPublicWebDbContext context;
        private readonly IMailService mailService;

        public ContactRepository(SpipamaPublicWebDbContext context, IMailService mailService)
        {
            this.context = context;
            this.mailService = mailService;
        }

        public async Task<bool> SendEmail(SendEmailDTO sendEmailDTO)
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json");
            var config = builder.Build();

            EmailTemplates emailTemplate = await context.EmailTemplates.Where(x => x.Name == "SendEmailDefault").SingleAsync();
            await mailService.SendEmail(emailTemplate.Subject, emailTemplate.Body.Replace("{{Name}}", sendEmailDTO.Name).Replace("{{Surname}}", sendEmailDTO.Surname).Replace("{{Email}}", sendEmailDTO.Email).Replace("{{Message}}", sendEmailDTO.Message), new List<string> { config["ContactEmail"] });
            return true;


        }
    }
}
