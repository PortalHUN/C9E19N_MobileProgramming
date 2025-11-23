using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApplication.Interfaces;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

  [RelayCommand]
  public async Task UpdateAsync()
  {
    var param = new ShellNavigationQueryParameters
    {
      { "Recipe", SelectedRecipe }
    };
    await Shell.Current.GoToAsync("///RecipeEditor", param);
  }

  [RelayCommand]
  public async Task ShareAsync()
  {
    string str = $"{SelectedRecipe.Name}\n{SelectedRecipe.Description}";
    await Share.RequestAsync(new ShareTextRequest
    {
      Title = "Share Recipe",
      Text = str
    });
  }
}

