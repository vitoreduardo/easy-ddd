using EasyDDD.Infrastructure.Data.Repositories;
using EasyDDD.SharedKernel.Interfaces;

namespace EasyDDD.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddDependencyInjectionDefault(this IServiceCollection service)
        {
            service.AddScoped(typeof(IReadRepositoryBase<>), typeof(ReadRepositoryBase<>));
            service.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            return service;
        }
    }
}
