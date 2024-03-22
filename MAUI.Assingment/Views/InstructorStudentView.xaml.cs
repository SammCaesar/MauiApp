using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Views;

public partial class InstructorStudentView : ContentPage
{
	public InstructorStudentView()
	{
		InitializeComponent();
        BindingContext = new InstructorViewModel();
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
    private void AddStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//StudentDetails");
        //(BindingContext as InstructorViewModel)?.AddStudent();
    }
    private void UpdateStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//UpdateStudentDetails");
        //(BindingContext as InstructorViewModel)?.AddStudent();
    }
    private void DeleteStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewModel)?.DeleteStudent();
    }
    private void EnrollStudentClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EnrollmentDetails");
        //(BindingContext as InstructorViewModel)?.EnrollStudent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel)?.RefreshView();
    }
}