using CommunityToolkit.Maui;
using MAUI_Demo.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Acr.UserDialogs;
using FFImageLoading.Maui;

namespace MAUI_Demo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseFFImageLoading()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-brands-400.ttf", "FaBrands");
                fonts.AddFont("fa-solid-900.ttf", "FAS");
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                fonts.AddFont("Sitka.ttc", "Sitka");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
                fonts.AddFont("Strande2.ttf", "Strande2");
            })
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnApplicationCreate(app => UserDialogs.Init(app)));
#endif
            })
            .ConfigureMauiHandlers(h =>
			{
             FormHandler.RemoveBorders();  //For remove border in entry and picker control
         }).UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
