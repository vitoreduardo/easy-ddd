using EasyDDD.Infrastructure.CrossCutting.Events;
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
            service.AddScoped<IDomainEventDispatcher, MediatrDomainEventDispatcher>();

            return service;
        }
    }
}
