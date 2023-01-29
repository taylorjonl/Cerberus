using CommunityToolkit.Mvvm.ComponentModel;

namespace Cerberus.Presentation.Workspaces;

public partial class MasterDetailsWorkspaceViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? masterView;

    [ObservableProperty]
    private ViewModelBase? activeDetailsView;
}