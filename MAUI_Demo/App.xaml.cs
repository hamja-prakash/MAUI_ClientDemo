using MAUI_Demo.Helpers;
using MAUI_Demo.Views;

namespace MAUI_Demo;

public partial class App : Application
{
    private static Database database;

    public static Database Database
    {
        get
        {
            if (database == null)
            {
                database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		MainPage = new  NavigationPage(new LoginPage());
	}
}
