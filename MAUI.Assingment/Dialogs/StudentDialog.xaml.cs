using MAUI.Assingment.ViewModels;

namespace MAUI.Assingment.Dialogs;

public partial class StudentDialog : ContentPage
{
	public StudentDialog()
	{
		InitializeComponent();
        BindingContext = new StudentDialogViewModel();
	}
    private void AddStudentButtonClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddStudent();
        Shell.Current.GoToAsync("//Instructor");
        //Student? student = (BindingContext as StudentDialogViewModel)?.Student;
        //if (student != null)
        //{
        //    PersonService.Current.Add(student);
        //}
    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDialogViewModel();
    }
}