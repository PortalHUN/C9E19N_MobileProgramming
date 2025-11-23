using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
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
    [property:PrimaryKey]
    [property:AutoIncrement]
    int id;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    int rating;

    [ObservableProperty]
    string imagePath;

    [ObservableProperty]
    DateTime createdAt;

    [ObservableProperty]
    bool hasImage;

    public Recipe GetCopy()
    {
      return (Recipe)this.MemberwiseClone();
    }
  }
}
