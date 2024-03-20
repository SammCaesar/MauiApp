namespace MAUI.Assingment.Views;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}