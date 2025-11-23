namespace MobileApplication.Pages.RecipeDetail;

public partial class RecipeDetail : ContentPage
{
	private RecipeDetailViewModel vm;
	public RecipeDetail(RecipeDetailViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;
	}

  protected override void OnNavigatedTo(NavigatedToEventArgs args)
  {
    base.OnNavigatedTo(args);
		vm.InitDraft();
  }
}