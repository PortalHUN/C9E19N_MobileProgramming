using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApplication.Interfaces;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeList;

[QueryProperty(nameof(EditedRecipe), "EditedRecipe")]
public partial class RecipeListViewModel : ObservableObject
{
  private IRecipeData _database;
  public ObservableCollection<Recipe> Recipes { get; set; }

  [ObservableProperty]
  Recipe selectedRecipe;

  [ObservableProperty]
  private Recipe editedRecipe;

  public RecipeListViewModel(IRecipeData database)
  {
    _database = database;
    Recipes = new ObservableCollection<Recipe>();
  }

  public async Task InitializeAsync()
  {
    var recipeList = await _database.GetRecipesAsync();
    Recipes.Clear();
    recipeList.ForEach(e => Recipes.Add(e));
  }

  [RelayCommand]
  public async Task NewRecipeAsync()
  {
    SelectedRecipe = null;
    var param = new ShellNavigationQueryParameters
    {
      { "Recipe", new Recipe(){CreatedAt = DateTime.Now, Rating = 1 } }
    };
    await Shell.Current.GoToAsync("///RecipeEditor", param);
  }

  [RelayCommand]
  public async Task DetailViewAsync(Recipe Recipe)
  {
    if (SelectedRecipe != null)
    {
      Debug.WriteLine("ASDSADASDS");
    }
    SelectedRecipe = null;
  }
}

