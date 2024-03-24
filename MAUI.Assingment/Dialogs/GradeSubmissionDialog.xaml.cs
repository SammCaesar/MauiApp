using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class GradeSubmissionDialog : ContentPage
{
	public GradeSubmissionDialog()
	{
		InitializeComponent();
        BindingContext = new GradeAssignmentDialogViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new GradeAssignmentDialogViewModel();
    }
    private void GradeSubmissionButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as GradeAssignmentDialogViewModel)?.GradeSubmission();
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
}