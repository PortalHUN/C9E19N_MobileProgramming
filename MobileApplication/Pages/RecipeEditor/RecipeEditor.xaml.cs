using CommunityToolkit.Mvvm.Messaging;

namespace MobileApplication.Pages.RecipeEditor;

public partial class RecipeEditor : ContentPage
{
	private RecipeEditorViewModel vm;
	public RecipeEditor(RecipeEditorViewModel _vm)
	{
		InitializeComponent();
		this.vm = _vm;
		BindingContext = vm;
		WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
		{
			await DisplayAlert("Error", m, "Ok");
		});
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs e)
	{
		base.OnNavigatedTo(e);
		vm.InitDraft();
	}

}