using System;
using Cerberus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Cerberus.Presentation.Workspaces;

public class MasterDetailsWorkspace : IMasterDetailsWorkspace
{
    private readonly IDependencyResolver resolver;

    public MasterDetailsWorkspace(IDependencyResolver resolver)
    {
        this.resolver = resolver.CreateChildResolver(services =>
        {
            services.AddSingleton<IMasterDetailsWorkspace>(this);
        });
        this.ViewModel = this.resolver.Resolve<MasterDetailsWorkspaceViewModel>();
    }

    public MasterDetailsWorkspaceViewModel ViewModel { get; }

    public void ShowMasterView<TViewModel>(Action<TViewModel>? configure = null)
        where TViewModel : ViewModelBase
    {
        var viewModel = this.resolver.Resolve<TViewModel>();
        configure?.Invoke(viewModel);
        this.ViewModel.MasterView = viewModel;
    }

    public void ShowDetailsView<TViewModel>(Action<TViewModel>? configure = null)
        where TViewModel : ViewModelBase
    {
        var viewModel = this.resolver.Resolve<TViewModel>();
        configure?.Invoke(viewModel);
        this.ViewModel.ActiveDetailsView = viewModel;
    }
}
