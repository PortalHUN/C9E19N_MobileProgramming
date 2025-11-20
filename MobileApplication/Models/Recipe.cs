using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Model
{
  public partial class Recipe:ObservableObject
  {
    [ObservableProperty]
    int id;
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string description;

    [ObservableProperty]
    string imagePath;

    [ObservableProperty]
    DateTime createdAt;

    public Recipe GetCopy()
    {
      return (Recipe)this.MemberwiseClone();
    }
  }
}
