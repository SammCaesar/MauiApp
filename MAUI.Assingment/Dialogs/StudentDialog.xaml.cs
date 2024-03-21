namespace MAUI.Assingment.Dialogs;

public partial class StudentDialog : ContentPage
{
	public StudentDialog()
	{
		InitializeComponent();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}