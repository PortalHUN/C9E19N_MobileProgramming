using CommunityToolkit.Mvvm.ComponentModel;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeEditor;

[QueryProperty(nameof(editedRecipe), "Recipe")]
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

}

