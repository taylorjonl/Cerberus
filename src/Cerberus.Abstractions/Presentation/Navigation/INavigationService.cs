using System;
using System.Threading.Tasks;

namespace Cerberus.Presentation.Navigation;

public interface INavigationService
{
    ViewModelBase? ActiveView { get; }
    Task GoToAsync<TViewModel>(Action<TViewModel>? configure = null)
        where TViewModel : ViewModelBase;
}
