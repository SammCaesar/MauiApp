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
        Shell.Current.GoToAsync("//InstructorCourse");
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorCourse");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel();
    }
}