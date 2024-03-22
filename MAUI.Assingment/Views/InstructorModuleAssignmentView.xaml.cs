using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Views;

public partial class InstructorModuleAssignmentView : ContentPage
{
	public InstructorModuleAssignmentView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorCourse");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new InstructorViewModel();
    }
    private void AddModuleClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ModuleDetails");
    }
    private void AddAssignmentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AssignmentDetails");
    }
}