using Microsoft.Extensions.DependencyInjection;
using Spipama.Application.Interfaces;
using Spipama.Application.Services;
using Spipama.Domain.Models;
using Spipama.Infrastructure.Data.Helpers;
using Spipama.Infrastructure.Data.Interfaces;
using Spipama.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spipama.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Infrastructure.Data Layer
            services.AddScoped<IMeasureRepository, MeasureRepository>();
            services.AddScoped<IOverviewRepository, OverviewRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IFileManagementRepository, FileManagementRepository>();

            //Application Layer 
            services.AddScoped<IMeasureService, MeasureService>();
            services.AddScoped<IOverviewService, OverviewService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IFileManagementService, FileManagementService>();
            services.AddScoped<IGenericRepository<FileManagement>, GenericRepository<FileManagement>>();
        }
    }
}
