using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cerberus.DependencyInjection;

public class DependencyResolver : IDependencyResolver
{
    public DependencyResolver(IServiceProvider serviceProvider)
        : this(null, serviceProvider)
    {
    }

    internal DependencyResolver(IDependencyResolver? parentResolver, IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        this.ServiceProvider = parentResolver != null ? new CompositeServiceProvider(serviceProvider, parentResolver.ServiceProvider) : serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; }

    public IDependencyResolver CreateChildResolver(Action<IServiceCollection> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var services = new ServiceCollection();
        configure(services);
        return new DependencyResolver(this, services.BuildServiceProvider());
    }

    public T Resolve<T>()
        where T : class
    {
        if (typeof(T) == typeof(IDependencyResolver))
        {
            return (T)Convert.ChangeType(this, typeof(IDependencyResolver));
        }
        var value = this.ServiceProvider.GetService<T>();
        if (value is not null)
        {
            return value;
        }
        return ActivatorUtilities.CreateInstance<T>(this.ServiceProvider);
    }

    private sealed class CompositeServiceProvider : IServiceProvider
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IServiceProvider parentServiceProvider;

        public CompositeServiceProvider(IServiceProvider serviceProvider, IServiceProvider parentServiceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            ArgumentNullException.ThrowIfNull(parentServiceProvider);

            this.serviceProvider = serviceProvider;
            this.parentServiceProvider = parentServiceProvider;
        }

        public object GetService(Type serviceType)
        {
            var instance = this.serviceProvider.GetService(serviceType) ?? this.parentServiceProvider.GetService(serviceType);
            if (instance is null)
            {
                throw new InvalidOperationException();
            }
            return instance;
        }
    }
}
