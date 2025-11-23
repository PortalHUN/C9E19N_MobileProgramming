using CommunityToolkit.Mvvm.ComponentModel;
using MobileApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Pages.RecipeDetail;

[QueryProperty(nameof(selectedRecipe), "selectedRecipe")]
public partial class RecipeDetailViewModel : ObservableObject
{
  [ObservableProperty]
  Recipe selectedRecipe;


}

