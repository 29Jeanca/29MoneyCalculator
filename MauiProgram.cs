using _29_Money_Calculator.BD;
using _29MoneyCalculator.Class;
using _29MoneyCalculator.Class.Interfaces;
using _29MoneyCalculator.Data;
using Microsoft.Extensions.Logging;

namespace _29MoneyCalculator
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
                });
            builder.Services.AddScoped<ConxDB>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IDialogService,DialogService>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}