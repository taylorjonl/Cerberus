using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MonkeyMadness.Constants;
using MonkeyMadness.Maui.Presentation.Views;

namespace MonkeyMadness.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddMonkeyMadnessMaui();

        // temporary
        Routing.RegisterRoute(ViewNames.Main, typeof(MainView));
        Routing.RegisterRoute(ViewNames.MonkeyDetails, typeof(MonkeyDetailsView));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}
