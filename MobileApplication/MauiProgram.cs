using Microsoft.Extensions.Logging;
using MobileApplication.Connections;
using MobileApplication.Interfaces;

namespace MobileApplication
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
      builder.Services.AddSingleton<IRecipeData, RecipeSQLite>();

#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
