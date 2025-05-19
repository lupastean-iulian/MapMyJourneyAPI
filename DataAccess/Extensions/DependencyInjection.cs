using Microsoft.Extensions.DependencyInjection;
using MapMyJourneyAPI.DataAccess.Repositories;
using MapMyJourneyAPI.Domain.Interfaces;

namespace MapMyJourneyAPI.DataAccess.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            return services;
        }
    }
}