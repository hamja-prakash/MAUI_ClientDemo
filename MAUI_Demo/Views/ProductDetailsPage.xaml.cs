using MAUI_Demo.API;
using MAUI_Demo.Model;

namespace MAUI_Demo.Views;

public partial class ProductDetailsPage : ContentPage
{
    public int productId = 0;
    public Product products;
    public ProductAPI productAPI;

    //public ProductDetailsPage(int productid)
    //{
    //    InitializeComponent();
    //    productAPI = new ProductAPI();
    //    this.productId = productid;
    //    //lblTotal.Text = grdStepper.Text.ToString();
    //}

    public ProductDetailsPage(Product _products)
    {
        InitializeComponent();
        productAPI = new ProductAPI();
        this.products = _products;
    }


    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await GetProductDetails(this.products);
    }

    public async Task GetProductDetails(Product mproduct)
    {
        try
        {
            //ShowLoader(true);
            //var productDetailsResult = await productAPI.ProductDetailsByProductId(Id);
            grdmain.IsVisible = true;
            //ShowLoader(false);
            txtProductName.Text = mproduct.title;
            imgProduct.Source = mproduct.image;
            lblPrice.Text = "$ " + mproduct.price.ToString();
            txtProductDesc.Text = mproduct.description;
        
            //var productDetailsResult = await productAPI.ProductDetailsByProductId(Id);
            //if (productDetailsResult != null)
            //{
            //    grdmain.IsVisible = true;
            //    ShowLoader(false);
            //    txtProductName.Text = productDetailsResult.title;
            //    imgProduct.Source = productDetailsResult.image;
            //    lblPrice.Text = "$ " + productDetailsResult.price.ToString();
            //    txtProductDesc.Text = productDetailsResult.description;
            //}
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

private void imgBack_Clicked(object sender, EventArgs e)
{
    Navigation.PopAsync();
}

private async void FrmAddcart_Tapped(object sender, EventArgs e)
{
    try
    {
        await FrmAddcart.ScaleTo(0.9, 100, Easing.Linear);
        await FrmAddcart.ScaleTo(1.0, 100, Easing.Linear);
    }
    catch (Exception)
    {
        throw;
    }
}
}