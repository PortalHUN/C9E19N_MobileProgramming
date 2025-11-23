using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeEditor;

[QueryProperty(nameof(EditedRecipe), "Recipe")]
public partial class RecipeEditorViewModel : ObservableObject
{
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
    var photo = await MediaPicker.CapturePhotoAsync();
    if (photo != null)
    {
      string fileName = $"{Guid.NewGuid}.jpg";
      string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

      using Stream sourceStream = await photo.OpenReadAsync();
      using FileStream targetStream = File.OpenWrite(filePath);
      Draft.ImagePath = filePath;
    }
  }
}
