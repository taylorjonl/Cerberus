using CommunityToolkit.Mvvm.ComponentModel;

namespace MonkeyMadness.Presentation;

public partial class MainWindowModel : ObservableObject
{
    [ObservableProperty]
    private object content;
}
