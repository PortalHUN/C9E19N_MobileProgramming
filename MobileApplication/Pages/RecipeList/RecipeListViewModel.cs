using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApplication.Interfaces;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeList;

public partial class RecipeListViewModel : ObservableObject
{
  private IRecipeData _database;
  public ObservableCollection<Recipe> Recipes { get; set; }

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
    await Shell.Current.GoToAsync("///RecipeEditor");
  }
}

