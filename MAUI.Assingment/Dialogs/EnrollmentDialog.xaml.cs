using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class EnrollmentDialog : ContentPage
{
	public EnrollmentDialog()
	{
        InitializeComponent();
        BindingContext = new InstructorViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new InstructorViewModel();
    }
    private void EnrollStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.EnrollStudent();
    }
}