using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class UpdateStudentDialog : ContentPage
{
	public UpdateStudentDialog()
	{
		InitializeComponent(); 
        BindingContext = new UpdateStudentDialogViewModel();
    }
    private void UpdateStudentButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as UpdateStudentDialogViewModel)?.UpdateStudent();
        Shell.Current.GoToAsync("//InstructorStudent");
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorStudent");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new UpdateStudentDialogViewModel();
    }
}