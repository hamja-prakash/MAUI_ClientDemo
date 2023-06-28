using MAUI_Demo.ViewModels;

namespace MAUI_Demo.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        this.BindingContext = new LoginViewModel();
    }

    protected override void OnAppearing()
    {
		try
		{
			base.OnAppearing();
			txtEmail.Text = string.Empty;
			txtPassword.Text = string.Empty;
		}
		catch (Exception ex)
		{
			var err = ex.Message;
		}
    }

    protected override bool OnBackButtonPressed()
    {
        Device.BeginInvokeOnMainThread(async () =>
        {
            bool result = await DisplayAlert("Confirm Exit", "Are you sure you want to exit?", "Yes", "No");

            if (result)
            {
                Application.Current.Quit();
            }
        });
        return true; // Prevent default back button behavior
    }
}