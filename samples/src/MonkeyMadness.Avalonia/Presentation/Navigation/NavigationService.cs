using System;
using System.Threading.Tasks;
using Cerberus.DependencyInjection;
using Cerberus.Presentation;
using Cerberus.Presentation.Navigation;

namespace MonkeyMadness.Avalonia.Presentation.Navigation;

public class NavigationService : INavigationService
{
    private readonly MainWindowModel mainWindow;
    private readonly IDependencyResolver dependencyResolver;  // TODO: Find a better way, ViewModelLocator pattern?

    public NavigationService(MainWindowModel mainWindow, IDependencyResolver dependencyResolver)
    {
        this.mainWindow = mainWindow;
        this.dependencyResolver = dependencyResolver;
    }

    public ViewModelBase? ActiveView { get; private set; }

    public Task GoToAsync<TViewModel>(Action<TViewModel>? configure = null)
        where TViewModel : ViewModelBase
    {
        var viewModel = this.dependencyResolver.Resolve<TViewModel>();
        configure?.Invoke(viewModel);
        this.ActiveView = viewModel;
        this.mainWindow.Content = this.ActiveView;
        return Task.CompletedTask;
    }
}
