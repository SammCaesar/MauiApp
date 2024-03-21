using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class ModuleDialog : ContentPage
{
	public ModuleDialog()
	{
		InitializeComponent();
        BindingContext = new ModuleDialogViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleDialogViewModel();
    }
    private void AddModuleButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleDialogViewModel)?.AddModule();
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
}