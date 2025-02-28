using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;
using MauiIcons.Material;


namespace SndMauiApp;

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
        builder.UseMaterialMauiIcons();
		builder.ConfigureSyncfusionToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
