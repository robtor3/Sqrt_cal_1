
using Microsoft.Extensions.Logging;
using Sqrt_cal_1.Services;
using Sqrt_cal_1.ViewModels;

namespace Sqrt_cal_1
{
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

            
            builder.Services.AddSingleton<SettingsServices>();  

            
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<SecondViewModel>();
            builder.Services.AddTransient<SettingsViewModel>(); 

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SecondPage>();
            builder.Services.AddTransient<SettingsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}