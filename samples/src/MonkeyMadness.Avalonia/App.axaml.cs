using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Cerberus;

namespace MonkeyMadness.Avalonia;

public partial class App : Application
{
    private readonly Bootstrapper bootstrapper = new AvaloniaBootstrapper();

    public override void Initialize()
    {
        bootstrapper.Run();

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = bootstrapper.DependencyResolver!.Resolve<MainWindowModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}