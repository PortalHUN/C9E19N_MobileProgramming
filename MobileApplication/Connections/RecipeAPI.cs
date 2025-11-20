using MobileApplication.Interfaces;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileApplication.Connections
{
  public class RecipeAPI : IRecipeData
  {
    HttpClient client;
    JsonSerializerOptions serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
    string localhost = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
    Uri URI;

    public RecipeAPI()
    {
      URI = new Uri($"http://{localhost}:5247/Recipe");
      client = new HttpClient();
    }


    public Task<List<Recipe>> GetRecipesAsync()
    {
      throw new NotImplementedException();
    }


    public Task<Recipe> GetRecipeAsync(int id)
    {
      throw new NotImplementedException();
    }


    public Task CreateRecipeAsync(Recipe rec)
    {
      throw new NotImplementedException();
    }

    public Task UpdateRecipeAsync(Recipe rec)
    {
      throw new NotImplementedException();
    }

    public Task DeleteRecipeAsync(Recipe rec)
    {
      throw new NotImplementedException();
    }
  }
}
