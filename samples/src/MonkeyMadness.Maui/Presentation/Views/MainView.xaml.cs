using MonkeyMadness.Presentation.ViewModels;

namespace MonkeyMadness.Maui.Presentation.Views;

public partial class MainView
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
