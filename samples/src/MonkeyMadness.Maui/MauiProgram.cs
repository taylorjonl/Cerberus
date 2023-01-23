using Cerberus.Presentation.Alerting;
using Cerberus.Presentation.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MonkeyMadness.Constants;
using MonkeyMadness.Maui.Presentation.Alerting;
using MonkeyMadness.Maui.Presentation.Navigation;
using MonkeyMadness.Maui.Presentation.Views;

namespace MonkeyMadness.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var bootstrapper = new MauiBootstrapper();

        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IAlertService, AlertService>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();

		// temporary
		Routing.RegisterRoute(ViewNames.Main, typeof(MainView));
		Routing.RegisterRoute(ViewNames.MonkeyDetails, typeof(MonkeyDetailsView));

		bootstrapper.ConfigureServices(builder.Services);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		bootstrapper.Configure(app.Services);

        return app;
	}
}
