using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Views;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
        BindingContext = new StudentViewModel();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void SeeCoursesClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.RefreshView();
    }
    private void SeeDetailedCoursesClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentCourse");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as StudentCourseViewModel)?.RefreshView();
    }
}