using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Views;

public partial class InstructorCourseView : ContentPage
{
	public InstructorCourseView()
	{
		InitializeComponent();
        BindingContext = new InstructorViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
    private void AddCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetails");
    }
    private void UpdateCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//UpdateCourseDetails");
    }
    private void AddModuleAssignmentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorModuleAssignment");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel)?.RefreshView();
    }
}