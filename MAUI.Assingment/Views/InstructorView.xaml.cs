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
    private void InstructorStudentViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorStudent");
    }
    private void InstructorCourseViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorCourse");
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
    private void AddCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetails");
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