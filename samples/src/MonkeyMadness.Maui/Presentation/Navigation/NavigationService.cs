using System;
using System.Threading.Tasks;
using Cerberus.Presentation;
using Cerberus.Presentation.Navigation;
using Microsoft.Maui.Controls;

namespace MonkeyMadness.Maui.Presentation.Navigation;

public class NavigationService : INavigationService
{
    public ViewModelBase? ActiveView { get; set; }

    public async Task GoToAsync<TViewModel>(Action<TViewModel>? configure = null)
        where TViewModel : ViewModelBase
    {
        // TODO: Find a better way to do this, the page should be validated before not after
        await Shell.Current.GoToAsync(typeof(TViewModel).Name.Replace("ViewModel", ""), true);
        if (Shell.Current.CurrentPage.BindingContext is not TViewModel viewModel)
        {
            throw new InvalidOperationException();
        }
        configure?.Invoke(viewModel);
        this.ActiveView = viewModel;
    }
}
