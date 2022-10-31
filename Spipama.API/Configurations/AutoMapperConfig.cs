using Microsoft.Extensions.DependencyInjection;
using Spipama.Application.AutoMapper;

namespace Spipama.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
