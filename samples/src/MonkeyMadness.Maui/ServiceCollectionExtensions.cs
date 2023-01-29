using Cerberus.Presentation.Alerting;
using Cerberus.Presentation.Navigation;
using Microsoft.Extensions.DependencyInjection;
using MonkeyMadness.Maui.Presentation.Alerting;
using MonkeyMadness.Maui.Presentation.Navigation;
using MonkeyMadness.Maui.Presentation.Views;
using MonkeyMadness.Presentation;

namespace MonkeyMadness.Maui;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMonkeyMadnessMaui(this IServiceCollection services)
    {
        services.AddMonkeyMadness();

        services.AddSingleton<IAlertService, AlertService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddTransient<MainView>();
        services.AddTransient<MonkeyDetailsView>();

        services.AddSingleton<MainWindowModel>();

        return services;
    }
}
