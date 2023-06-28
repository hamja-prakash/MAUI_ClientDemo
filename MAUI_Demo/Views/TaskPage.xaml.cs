using MAUI_Demo.ViewModels;

namespace MAUI_Demo.Views;

public partial class TaskPage : ContentPage
{
	public TaskPage()
	{
		InitializeComponent();
        this.BindingContext = new TaskViewModel();
    }
}