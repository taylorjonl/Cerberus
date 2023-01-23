using CommunityToolkit.Mvvm.ComponentModel;

namespace MonkeyMadness.Avalonia;

public partial class MainWindowModel : ObservableObject
{
    [ObservableProperty]
    private object content;
}
