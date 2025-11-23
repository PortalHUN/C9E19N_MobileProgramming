using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApplication.Interfaces;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeDetail;

[QueryProperty(nameof(SelectedRecipe), "selectedRecipe")]
public partial class RecipeDetailViewModel : ObservableObject
{
  private IRecipeData _database;
  [ObservableProperty]
  Recipe selectedRecipe;

  public RecipeDetailViewModel(IRecipeData database)
  {
    _database = database;
  }

  [RelayCommand]
  public async Task BackAsync()
  {
    await Shell.Current.GoToAsync("///RecipeList");
  }

  [RelayCommand]
  public async Task DeleteAsync()
  {
    await _database.DeleteRecipeAsync(SelectedRecipe);
    await Shell.Current.GoToAsync("///RecipeList");
  }
}

