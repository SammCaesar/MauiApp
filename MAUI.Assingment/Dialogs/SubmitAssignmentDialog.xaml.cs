using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class SubmitAssignmentDialog : ContentPage
{
	public SubmitAssignmentDialog()
	{
		InitializeComponent();
        BindingContext = new SubmitAssignmentDialogViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentCourse");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SubmitAssignmentDialogViewModel();
    }
    private void SubmitButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as SubmitAssignmentDialogViewModel)?.SubmitAssignment();
    }
}