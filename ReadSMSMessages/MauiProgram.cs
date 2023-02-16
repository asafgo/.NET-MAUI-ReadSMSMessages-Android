﻿#if ANDROID
using ReadSMSMessages.Platforms;
#endif

using Microsoft.Extensions.Logging;

namespace ReadSMSMessages;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<MainPage>();

#if ANDROID
		builder.Services.AddSingleton<IMyReadSMS, MyReadSMS>();
#endif
        return builder.Build();
	}
}
