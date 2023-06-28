using MAUI_Demo.API;
using MAUI_Demo.Model;
using MvvmHelpers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MAUI_Demo.Views;

public partial class ProductPage : ContentPage
{
    public ProductAPI productAPI;
    public ObservableCollection<Grouping<string, Product>> mProducts;
    List<Product> productList = new List<Product>();

    public ProductPage()
    {
        InitializeComponent();
        productAPI = new ProductAPI();
        mProducts = new ObservableCollection<Grouping<string, Product>>();
        Device.BeginInvokeOnMainThread(async () =>
        {
            await BindAllProducts();
        });
    }

    //protected async override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    await BindAllProducts();
    //}

    //protected override void OnDisappearing()
    //{
    //    base.OnDisappearing();
    //    Home?.OnDisappearing();
    //}

    public async Task BindAllProducts()
    {
        try
        {
            //ShowLoader(true);
            //var productResult = await productAPI.GetProducts();
            //if (productResult != null && productResult.Count > 0)
            //{
            //    ShowLoader(false);
            //    //var items = from item in productResult
            //    //            orderby
            //    //            item.category
            //    //            group item by item.category.ToUpper().ToString() into categoryGroup
            //    //            select new Grouping<string, Product>(categoryGroup.Key, categoryGroup);

            //    //foreach (var item in items)
            //    //    mProducts.Add(item);
            //    clvProducts.ItemsSource = productResult;
            //}
            var stream = FileSystem.OpenAppPackageFileAsync("products.json");
            using (StreamReader reader = new StreamReader(await stream))
            {
                string jsonString = reader.ReadToEnd();
                productList = JsonConvert.DeserializeObject<List<Product>>(jsonString);
                clvProducts.ItemsSource = productList;
                //ShowLoader(false);
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }

    public void ShowLoader(bool isLoad)
    {
        try
        {
            grdloader.IsVisible = isLoad;
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }

    private void FrmProduct_Tapped(object sender, EventArgs e)
    {

        try
        {
            if (sender is Frame frmProduct && frmProduct.BindingContext is Product product)
            {
                if (product != null)
                    Navigation.PushAsync(new ProductDetailsPage(product));
                    //Navigation.PushAsync(new ProductDetailsPage(product.id));
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }
}