using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MonkeyMadness.Maui;

public partial class App
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        window.Width = 400;
        window.Height = 800;
        return window;
    }
}
