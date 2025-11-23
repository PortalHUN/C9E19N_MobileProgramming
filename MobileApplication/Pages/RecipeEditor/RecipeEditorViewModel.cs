using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MobileApplication.Interfaces;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeEditor;

[QueryProperty(nameof(EditedRecipe), "Recipe")]
public partial class RecipeEditorViewModel : ObservableObject
{
  private IRecipeData _database;

  public RecipeEditorViewModel(IRecipeData database)
  {
    _database = database;
  }

  [ObservableProperty]
  Recipe editedRecipe;

  [ObservableProperty]
  Recipe draft;

  public void InitDraft()
  {
    Draft = EditedRecipe.GetCopy();
  }

  [RelayCommand]
  public async Task TakePhoto()
  {
    var photo = await MediaPicker.PickPhotoAsync();
    if (photo != null)
    {
      string fileName = $"{Guid.NewGuid()}.jpg";
      string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
      using Stream sourceStream = await photo.OpenReadAsync();
      using FileStream targetStream = File.OpenWrite(filePath);
      await sourceStream.CopyToAsync(targetStream);
      Draft.ImagePath = filePath;
      Draft.HasImage = true;
    }
  }

  [RelayCommand]
  public async Task SavePet()
  {
    if (Draft.Name != null || Draft.Name == "")
    {
      await _database.CreateRecipeAsync(Draft);
      await Shell.Current.GoToAsync("///RecipeList");
    }
    else
    {
      WeakReferenceMessenger.Default.Send("Missing recipe name.");
    }
  }

  [RelayCommand]
  public async Task Cancel()
  {
    await Shell.Current.GoToAsync("///RecipeList");
  }
}
