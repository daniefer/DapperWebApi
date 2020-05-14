using DapperBusiness.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DapperBusiness
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services)
        {
            DapperUtilities.RegisterDapperHandlers();

            services.TryAddTransient<GetHouseEvents>();
            services.TryAddTransient<GetHouseSources>();
            services.TryAddTransient<GetHouseEventTypes>();
            services.TryAddTransient<SaveHouseEvents>();
            services.TryAddTransient<SaveHouseSources>();

            return services;
        }
    }
}
