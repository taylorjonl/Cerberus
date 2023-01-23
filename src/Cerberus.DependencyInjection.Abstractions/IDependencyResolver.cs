using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cerberus.DependencyInjection;

public interface IDependencyResolver
{
    IServiceProvider ServiceProvider { get; }
    IDependencyResolver CreateChildResolver(Action<IServiceCollection> configure);
    T Resolve<T>()
        where T : class;
}
