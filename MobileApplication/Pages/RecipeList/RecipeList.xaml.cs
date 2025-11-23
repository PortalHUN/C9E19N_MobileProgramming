using CommunityToolkit.Mvvm.Messaging;

namespace MobileApplication.Pages.RecipeList;

public partial class RecipeList : ContentPage
{
	private RecipeListViewModel vm;

	public RecipeList(RecipeListViewModel _vm)
	{
		InitializeComponent();
		this.vm = _vm;
		BindingContext = vm;
		WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
		{
			await DisplayAlert("Warning", m, "Ok");
		});
	}

	private async void RecipeList_OnLoaded(object? sender, EventArgs e)
	{
		await vm.InitializeAsync();
	}
}