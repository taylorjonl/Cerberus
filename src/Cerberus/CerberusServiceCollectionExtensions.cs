using Cerberus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Cerberus;

public static class CerberusServiceCollectionExtensions
{
    public static IServiceCollection AddCerberus(this IServiceCollection services)
    {
        services.AddSingleton<IDependencyResolver, DependencyResolver>();
        return services;
    }
}
