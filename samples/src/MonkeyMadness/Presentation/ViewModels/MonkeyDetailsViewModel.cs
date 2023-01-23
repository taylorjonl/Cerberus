using Cerberus.Presentation;
using CommunityToolkit.Mvvm.ComponentModel;
using MonkeyMadness.Data;

namespace MonkeyMadness.Presentation.ViewModels;

public partial class MonkeyDetailsViewModel : ViewModelBase
{
    [ObservableProperty]
    private Monkey monkey;
}
