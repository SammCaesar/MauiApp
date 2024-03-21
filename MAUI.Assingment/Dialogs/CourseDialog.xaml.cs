using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class CourseDialog : ContentPage
{
	public CourseDialog()
	{
		InitializeComponent();
        BindingContext = new CourseDialogViewModel();
    }
    private void AddCourseButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Instructor");
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel();
    }
}