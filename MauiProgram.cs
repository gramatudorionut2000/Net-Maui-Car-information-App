using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Proiect;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("ProximaNovaBold.otf", "ProximaNovaBold");
                fonts.AddFont("ProximaNova-Regular.otf", "ProximaNovaRegular");
            });

		return builder.Build();
	}
}
