using MonkeyMadness.Presentation.ViewModels;

namespace MonkeyMadness.Maui.Presentation.Views;

public partial class MonkeyDetailsView
{
    public MonkeyDetailsView(MonkeyDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
