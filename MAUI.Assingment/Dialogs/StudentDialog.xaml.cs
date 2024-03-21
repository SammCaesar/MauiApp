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

    }
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}