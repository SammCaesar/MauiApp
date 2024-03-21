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

    private void AddStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDetails");
        //(BindingContext as InstructorViewModel)?.AddStudent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel).RefreshView();
    }
}