using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Interfaces
{
  public interface IRecipeData
  {
    Task<List<Recipe>> GetRecipesAsync();
    Task<Recipe> GetRecipeAsync(int id);
    Task CreateRecipeAsync(Recipe rec);
    Task DeleteRecipeAsync(Recipe rec);
    Task UpdateRecipeAsync(Recipe rec);
  }
}
