using System;

namespace Cerberus.Presentation.Workspaces
{
    public interface IMasterDetailsWorkspace
    {
        void ShowMasterView<TViewModel>(Action<TViewModel>? configure = null)
            where TViewModel : ViewModelBase;

        void ShowDetailsView<TViewModel>(Action<TViewModel>? configure = null)
            where TViewModel : ViewModelBase;
    }
}
