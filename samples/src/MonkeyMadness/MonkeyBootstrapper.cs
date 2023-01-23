using System;
using System.Threading.Tasks;
using Cerberus;
using Cerberus.Presentation.Navigation;
using Microsoft.Extensions.DependencyInjection;
using MonkeyMadness.Presentation.ViewModels;
using MonkeyMadness.Services;

namespace MonkeyMadness;

public class MonkeyBootstrapper : Bootstrapper
{
    protected override void ConfigureViews(IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
        services.AddTransient<MonkeyDetailsViewModel>();
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        services.AddSingleton<IMonkeyService, MonkeyService>();
        services.AddHttpClient<IMonkeyService, MonkeyService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://www.montemagno.com");
        });
    }

    // TODO: Find another way to allow bootstrapping with a lack of Microsoft DI, I want this sealed
    public override async Task Run()
    {
        INavigationService navigation = this.DependencyResolver!.Resolve<INavigationService>();
        await navigation.GoToAsync<MainViewModel>();
    }
}
