using System.Threading.Tasks;
using Cerberus.Presentation.Alerting;
using Cerberus.Presentation.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonkeyMadness.Services;
using Moq;

namespace MonkeyMadness.AcceptanceTests.Support;

public class TestsBootstrapper : MonkeyBootstrapper
{
    private static readonly IAlertService DefaultAlertService = Mock.Of<IAlertService>();
    private static readonly INavigationService DefaultNavigationService = Mock.Of<INavigationService>();
    private static readonly IMonkeyService DefaultMonkeyService = Mock.Of<IMonkeyService>();

    public IAlertService AlertService { get; set; } = DefaultAlertService;
    public INavigationService NavigationService { get; set; } = DefaultNavigationService;
    public IMonkeyService MonkeyService { get; set; } = DefaultMonkeyService;

    public override async Task Run()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddTransient<IAlertService>(_ => AlertService);
        builder.Services.AddTransient<INavigationService>(_ => NavigationService);
        builder.Services.AddTransient<IMonkeyService>(_ => DefaultMonkeyService);
        ConfigureServices(builder.Services);
        var host = builder.Build();
        Configure(host.Services);

        OnBeforeRun();
        await base.Run();
        OnAfterRun();
    }

    protected virtual void OnBeforeRun()
    {
    }

    protected virtual void OnAfterRun()
    {
    }
}
