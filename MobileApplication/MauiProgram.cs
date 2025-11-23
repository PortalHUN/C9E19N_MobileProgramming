using Microsoft.Extensions.Logging;
using MobileApplication.Connections;
using MobileApplication.Interfaces;
using MobileApplication.Pages.RecipeEditor;
using MobileApplication.Pages.RecipeList;

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
      builder.Services.AddSingleton<RecipeListViewModel>();
      builder.Services.AddSingleton<RecipeList>();
      builder.Services.AddTransient<RecipeEditorViewModel>();
      builder.Services.AddTransient<RecipeEditor>();
      builder.Services.AddSingleton<IRecipeData, RecipeSQLite>();

#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
