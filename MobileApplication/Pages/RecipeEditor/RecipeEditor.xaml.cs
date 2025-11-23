namespace MobileApplication.Pages.RecipeEditor;

public partial class RecipeEditor : ContentPage
{
	private RecipeEditorViewModel vm;
	public RecipeEditor(RecipeEditorViewModel _vm)
	{
		InitializeComponent();
		this.vm = _vm;
		BindingContext = vm;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs e)
	{
		base.OnNavigatedTo(e);
		vm.InitDraft();
	}
}