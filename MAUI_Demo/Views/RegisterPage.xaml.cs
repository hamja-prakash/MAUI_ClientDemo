using MAUI_Demo.ViewModels;

namespace MAUI_Demo.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        this.BindingContext = new RegisterViewModel();
    }
}