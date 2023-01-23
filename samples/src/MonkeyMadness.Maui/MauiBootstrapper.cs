using Microsoft.Extensions.DependencyInjection;
using MonkeyMadness.Maui.Presentation.Views;

namespace MonkeyMadness.Maui;

public class MauiBootstrapper : MonkeyBootstrapper
{
    protected override void ConfigureViews(IServiceCollection services)
    {
        base.ConfigureViews(services);

        services.AddTransient<MainView>();
        services.AddTransient<MonkeyDetailsView>();
    }
}
