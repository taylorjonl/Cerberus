using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonkeyMadness.Presentation;

namespace MonkeyMadness.Avalonia;

public partial class App : Application
{
    private MonkeyMadnessBootstrapper? bootstrapper;

    public override void Initialize()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddMonkeyMadnessAvalonia();
        var host = builder.Build();
        this.bootstrapper = host.Services.GetRequiredService<MonkeyMadnessBootstrapper>();

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = bootstrapper!.DependencyResolver!.Resolve<MainWindowModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}