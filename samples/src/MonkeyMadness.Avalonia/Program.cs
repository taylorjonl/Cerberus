using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Cerberus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonkeyMadness.Presentation;

namespace MonkeyMadness.Avalonia;

static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddMonkeyMadnessAvalonia();
        var host = builder.Build();
        var dependencyResolver = host.Services.GetRequiredService<IDependencyResolver>();
        var bootstrapper = dependencyResolver.Resolve<MonkeyMadnessBootstrapper>();

        var appBuilder = BuildAvaloniaApp();
        var lifetime = new ClassicDesktopStyleApplicationLifetime()
        {
            Args = args,
            ShutdownMode = ShutdownMode.OnLastWindowClose
        };
        appBuilder.SetupWithLifetime(lifetime);
        lifetime.MainWindow = new MainWindow
        {
            DataContext = bootstrapper.DependencyResolver.Resolve<MainWindowModel>(),
        };

        bootstrapper.Run();

        lifetime.Start(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
}
