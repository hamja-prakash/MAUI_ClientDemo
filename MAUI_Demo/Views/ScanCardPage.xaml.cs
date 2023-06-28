
namespace MAUI_Demo.Views;

public partial class ScanCardPage : ContentPage
{
    //public PayCard Card;
    public ScanCardPage()
	{
		InitializeComponent();
	}

	private async void btnScan_Clicked(object sender, EventArgs e)
	{
		try
		{
			//Card = await CrossPayCards.Current.ScanAsync().ConfigureAwait(true);
			//if (Card != null)
			//{
			//	lblHolderName.Text = Card.HolderName;
			//	lblCardNumber.Text = Card.CardNumber;
			//	lblExpirationDate.Text = Card.ExpirationDate;
			//}
		}
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }
}