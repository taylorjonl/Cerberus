using System.Threading.Tasks;
using Cerberus.Presentation.Alerting;
using Cerberus.Presentation.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonkeyMadness.Avalonia.Presentation.Alerting;
using MonkeyMadness.Avalonia.Presentation.Navigation;
using MonkeyMadness.Presentation;

namespace MonkeyMadness.Avalonia;

public class AvaloniaBootstrapper : MonkeyBootstrapper
{
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddSingleton<IAlertService, AlertService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<MainWindowModel>();
    }

    public override async Task Run()
    {
        var builder = Host.CreateApplicationBuilder();

        ConfigureServices(builder.Services);

        var host = builder.Build();

        Configure(host.Services);

        await base.Run();
    }
}

public class MonkeyMadnessAvaloniaAppBuilder : MonkeyMadnessAppBuilderBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddSingleton<IAlertService, AlertService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<MainWindowModel>();
    }
}
