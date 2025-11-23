using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
  [ObservableProperty]
  Recipe selectedRecipe;

  [ObservableProperty]
  Recipe draft;

  public bool hasImage
  {
    get
    {
      return Draft?.ImagePath != null && Draft?.ImagePath != "";
    }
    set
    {
      OnPropertyChanged();
    }
  }

  public void InitDraft()
  {
    Draft = SelectedRecipe.GetCopy();
    hasImage = true;
  }

  [RelayCommand]
  public async Task BackAsync()
  {
    await Shell.Current.GoToAsync("///RecipeList");
  }
}

