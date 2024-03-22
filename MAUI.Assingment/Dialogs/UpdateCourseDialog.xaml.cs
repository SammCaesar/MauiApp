using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class UpdateCourseDialog : ContentPage
{
	public UpdateCourseDialog()
	{
		InitializeComponent();
        BindingContext = new UpdateCourseDialogViewModel();
    }
    private void UpdateCourseButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as UpdateCourseDialogViewModel)?.UpdateCourse();
        Shell.Current.GoToAsync("//InstructorCourse");
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorCourse");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new UpdateCourseDialogViewModel();
    }
}