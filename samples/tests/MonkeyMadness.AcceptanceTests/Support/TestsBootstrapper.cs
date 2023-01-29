using System;
using Cerberus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MonkeyMadness.AcceptanceTests.Support;

public class TestsBootstrapper : MonkeyMadnessBootstrapper
{
    public TestsBootstrapper(IDependencyResolver dependencyResolver)
        : base(dependencyResolver)
    {
    }

    public static TBootstrapper Create<TBootstrapper>(Action<IServiceCollection>? configure = null)
        where TBootstrapper : class
    {
        var builder = Host.CreateApplicationBuilder();
        configure?.Invoke(builder.Services);
        builder.Services.AddMonkeyMadness();
        var host = builder.Build();
        var dependencyResolver = host.Services.GetRequiredService<IDependencyResolver>();
        return dependencyResolver.Resolve<TBootstrapper>();
    }

    public override void Run()
    {
        OnBeforeRun();
        base.Run();
        OnAfterRun();
    }

    protected virtual void OnBeforeRun()
    {
    }

    protected virtual void OnAfterRun()
    {
    }
}
