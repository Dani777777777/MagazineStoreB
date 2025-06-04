using Microsoft.Extensions.DependencyInjection;
using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.BL.Services;

namespace MagazineStoreB.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection 
            AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMagazineService, MagazineService>();
            services.AddSingleton<IBlMagazineService, BlMagazineService>();
            return services;
        }
    }
}
