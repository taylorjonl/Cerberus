using Avalonia;
using Avalonia.Markup.Xaml;

namespace MonkeyMadness.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}