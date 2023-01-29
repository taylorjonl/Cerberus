using Cerberus.Presentation.Alerting;
using Cerberus.Presentation.Navigation;
using Microsoft.Extensions.DependencyInjection;
using MonkeyMadness.Avalonia.Presentation.Alerting;
using MonkeyMadness.Avalonia.Presentation.Navigation;
using MonkeyMadness.Presentation;

namespace MonkeyMadness.Avalonia;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMonkeyMadnessAvalonia(this IServiceCollection services)
    {
        services.AddMonkeyMadness();

        services.AddSingleton<IAlertService, AlertService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddSingleton<MainWindowModel>();

        return services;
    }
}
