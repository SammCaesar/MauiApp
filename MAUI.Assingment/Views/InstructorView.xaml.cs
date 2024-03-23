using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
        BindingContext = new InstructorViewModel();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void SearchClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.RefreshView();
    }
    private void InstructorStudentViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorStudent");
    }
    private void InstructorCourseViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorCourse");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel)?.RefreshView();
    }
}