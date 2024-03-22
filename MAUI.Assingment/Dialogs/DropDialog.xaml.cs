using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class DropDialog : ContentPage
{
	public DropDialog()
	{
		InitializeComponent(); 
        BindingContext = new DropDialogViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorStudent");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as DropDialogViewModel)?.RefreshView();
    }
    private void DropStudentButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as DropDialogViewModel)?.DropStudent();
        Shell.Current.GoToAsync("//InstructorStudent");
    }
}