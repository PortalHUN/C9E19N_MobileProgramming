using MobileApplication.Interfaces;
using MobileApplication.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileApplication.Connections
{
  public class RecipeSQLite : IRecipeData
  {
    SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create;

    string databasePath = Path.Combine(FileSystem.Current.AppDataDirectory, "recipes.db3");
    SQLiteAsyncConnection database;

    public RecipeSQLite()
    {
      database = new SQLiteAsyncConnection(databasePath,Flags);
      database.CreateTableAsync<Recipe>().Wait();
    }

    public Task CreateRecipeAsync(Recipe rec)
    {
      throw new NotImplementedException();
    }

    public Task DeleteRecipeAsync(Recipe rec)
    {
      throw new NotImplementedException();
    }

    public Task<Recipe> GetRecipeAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Recipe>> GetRecipesAsync()
    {
      throw new NotImplementedException();
    }

    public Task UpdateRecipeAsync(Recipe rec)
    {
      throw new NotImplementedException();
    }
  }
}
