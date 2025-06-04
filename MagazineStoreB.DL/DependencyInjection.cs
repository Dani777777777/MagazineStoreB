using Microsoft.Extensions.DependencyInjection;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.DL.Repositories;
using MagazineStoreB.DL.Repositories.MongoRepositories;

namespace MagazineStoreB.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection 
            AddDataDependencies(
                this IServiceCollection services)
        {
            services.AddSingleton<IMagazineRepository, MagazinesRepository>();
            services.AddSingleton<IAuthorRepository, AuthorrRepository>();

            return services;
        }
    }
}
