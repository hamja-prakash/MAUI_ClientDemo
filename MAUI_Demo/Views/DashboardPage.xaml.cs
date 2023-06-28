using MAUI_Demo.Model;

namespace MAUI_Demo.Views;

public partial class DashboardPage : ContentPage
{
    #region [ Properties ]
    public List<Home> mHomes;
    #endregion

    public DashboardPage()
	{
		InitializeComponent();
        mHomes = new List<Home>();
        BindHomeData();
    }

    #region [ Methods ]
    public void BindHomeData()
    {
        try
        {
            
            mHomes.Add(new Home
            {
                Image = "product1.jpg",
                Name = "Bella",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product2.jpg",
                Name = "Bailey",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product3.jpg",
                Name = "Charlie",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product4.jpg",
                Name = "Buddy",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product5.jpg",
                Name = "Rocky",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product6.jpg",
                Name = "Teddy",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product7.jpg",
                Name = "Duke",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            mHomes.Add(new Home
            {
                Image = "product1.jpg",
                Name = "Zoe",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
            });

            clvHome.ItemsSource = mHomes.ToList();
        }
        catch (Exception ex)
        {
            var err = ex.Message;
        }
    }
    #endregion
}