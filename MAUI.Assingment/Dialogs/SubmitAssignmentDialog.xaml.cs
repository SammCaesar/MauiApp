using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class SubmitAssignmentDialog : ContentPage
{
	public SubmitAssignmentDialog()
	{
		InitializeComponent();
        BindingContext = new StudentCourseViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentCourse");
    }
}