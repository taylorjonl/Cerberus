using System;
using System.Threading.Tasks;
using Cerberus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Cerberus;

public abstract class Bootstrapper
{
    public IDependencyResolver? DependencyResolver { get; private set; }

    // TODO: Find another way, I don't want this to be virtual
    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDependencyResolver, DependencyResolver>();

        ConfigureViews(services);
    }

    protected abstract void ConfigureViews(IServiceCollection services);

    public void Configure(IServiceProvider serviceProvider)
    {
        this.DependencyResolver = serviceProvider.GetRequiredService<IDependencyResolver>();
    }

    public abstract Task Run();
}
