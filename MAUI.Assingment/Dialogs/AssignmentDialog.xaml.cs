using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class AssignmentDialog : ContentPage
{
	public AssignmentDialog()
	{
		InitializeComponent();
        BindingContext = new AssignmentDialogViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AssignmentDialogViewModel();
    }
    private void AddAssignmentButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentDialogViewModel)?.AddAssignment();
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
}