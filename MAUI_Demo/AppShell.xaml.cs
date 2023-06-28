using MAUI_Demo.Views;

namespace MAUI_Demo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    private async void btnLogout_Clicked(object sender, EventArgs e)
	{
		var isLogout = await DisplayAlert("Alert", "Are you sure you want to logout the app?", "OK", "Cancel");
		if(isLogout)
		{
			FlyoutIsPresented = false;
			await Navigation.PushAsync(new LoginPage());
			//Application.Current.MainPage = new LoginPage();
		}
	}
}
