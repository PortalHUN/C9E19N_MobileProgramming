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

    public async Task CreateRecipeAsync(Recipe rec)
    {
      await database.InsertAsync(rec);
    }

    public async Task DeleteRecipeAsync(Recipe rec)
    {
      await database.DeleteAsync(rec);
    }

    public async Task<Recipe> GetRecipeAsync(int id)
    {
      
      return await database.Table<Recipe>().Where(e=>e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
      return await database.Table<Recipe>().ToListAsync();
    }

    public async Task UpdateRecipeAsync(Recipe rec)
    {
      await database.UpdateAsync(rec);
    }
  }
}
