using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Views;

public partial class StudentCourseDetailView : ContentPage
{
	public StudentCourseDetailView()
	{
		InitializeComponent();
		BindingContext = new StudentCourseViewModel();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }
    private void SubmitAssignmentButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//SubmitAssignment");
    }
}