using System;
using Cerberus;
using Microsoft.Extensions.DependencyInjection;
using MonkeyMadness.Presentation.ViewModels;
using MonkeyMadness.Services;

namespace MonkeyMadness;

public static class MonkeyMadnessServiceCollectionExtensions
{
    public static IServiceCollection AddMonkeyMadness(this IServiceCollection services)
    {
        services.AddCerberus();

        services.AddTransient<MainViewModel>();
        services.AddTransient<MonkeyDetailsViewModel>();

        services.AddSingleton<IMonkeyService, MonkeyService>();
        services.AddHttpClient<IMonkeyService, MonkeyService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://www.montemagno.com");
        });

        return services;
    }

    // TODO: Find another way to allow bootstrapping with a lack of Microsoft DI, I want this sealed
    //public override async Task Run()
    //{
    //    INavigationService navigation = this.DependencyResolver!.Resolve<INavigationService>();
    //    await navigation.GoToAsync<MainViewModel>();
    //}
}
