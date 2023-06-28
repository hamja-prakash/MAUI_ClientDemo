using MAUI_Demo.Helpers;
using MAUI_Demo.Model;

namespace MAUI_Demo.Views;

public partial class UserPage : ContentPage
{
    #region [ Properties ]
    public List<User> mUsers;
   // UserDatabase userDatabase;
    public int UserId = 0;
    public ImageButton ImageButton;
    #endregion

    public UserPage()
	{
		InitializeComponent();
        mUsers = new List<Model.User>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindUserData();
    }

    #region [ Methods ]
    public async void BindUserData()
    {
        try
        {
            mUsers = await App.Database.GetPeopleAsync();
            if (mUsers != null && mUsers.Count > 0)
            {
                lblNoDataMsg.IsVisible = false;
                lstUsers.IsVisible = true;
                lstUsers.ItemsSource = mUsers.ToList();
            }
            else
            {
                lstUsers.IsVisible = false;
                lblNoDataMsg.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            Console.WriteLine(ex.Message);
        }
    }

    public void SearchUsersData()
    {
        try
        {
            if (!string.IsNullOrEmpty(txtSearchUser.Text) &&
                !string.IsNullOrWhiteSpace(txtSearchUser.Text) &&
                txtSearchUser.Text.Length >= 2)
            {
                lstUsers.ItemsSource = null;

                if (mUsers != null && mUsers.Count > 0)
                {
                    var mUserSearchList = mUsers.Where(x => x.DisplayName.ToLower().Contains(txtSearchUser.Text.ToLower()) ||
                                                            x.Address.ToLower().Contains(txtSearchUser.Text.ToLower()) ||
                                                            x.MobileNo.Contains(txtSearchUser.Text)).ToList();
                    if (mUserSearchList != null &&
                        mUserSearchList.Count > 0)
                    {
                        lstUsers.IsVisible = true;
                        lblNoDataMsg.IsVisible = false;
                        lstUsers.ItemsSource = mUserSearchList.ToList();
                    }
                    else
                    {
                        lblNoDataMsg.IsVisible = true;
                        lstUsers.IsVisible = false;
                    }
                }
            }
            else
            {
                lstUsers.IsVisible = true;
                lblNoDataMsg.IsVisible = false;
                lstUsers.ItemsSource = mUsers.ToList();
            }

        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }
    #endregion

    #region [ Events ]
    private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            Dispatcher.Dispatch(() =>
            {
                SearchUsersData();
            });
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }

    private void TxtSearch_Completed(object sender, EventArgs e)
    {
        try
        {
            Dispatcher.Dispatch(() =>
            {
                SearchUsersData();
            });
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }

    private void ImgSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Dispatcher.Dispatch(() =>
            {
                SearchUsersData();
            });
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }


    private void FrmUser_Tapped(object sender, EventArgs e)
    {
        if (sender is Frame frmUser && frmUser.BindingContext is Model.User mUser)
        {
            if (mUser != null)
            {
                App.Current.MainPage.DisplayAlert("User", "You have selected " + mUser.FirstName + "", "Ok");
            }
        }
    }

    private void btnAddUser_Click(object sender, EventArgs e)
    {
        try
        {
            //grdUser.IsVisible = false;
            //grdAddUser.IsVisible = true;
            Navigation.PushAsync(new AddUserPage());
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }

    private async void FrmSave_Tapped(object sender, EventArgs e)
    {
        try
        {
            await frmSave.ScaleTo(0.9, 100, Easing.Linear);
            await frmSave.ScaleTo(1.0, 100, Easing.Linear);
            if (ValidateControl())
            {
                User muser = new User();
                muser.FirstName = txtFirstName.Text;
                muser.LastName = txtLastName.Text;
                muser.Address = txtAddress.Text;
                muser.MobileNo = txtMobileNo.Text;
                muser.Email = txtEmail.Text;
                muser.UserImg = "img1.jpg";
                if (UserId > 0)
                {
                    muser.UserId = UserId;
                    await App.Database.UpdatePersonAsync(muser);
                }
                else
                   await App.Database.SavePersonAsync(muser);

                DisplayMessages.SuccessMessage(CommonMessages.UserSave);
                //await App.Current.MainPage.DisplayAlert("Alert", "User has been successfully save", "Ok");
                grdAddUser.IsVisible = false;
                grdUser.IsVisible = true;
                BindUserData();
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }

    public bool ValidateControl()
    {
        bool isValid = false;
        if (string.IsNullOrEmpty(txtFirstName.Text))
        {
            DisplayMessages.AlertMessage(CommonMessages.RequireFirstName);
            isValid = false;
        }
        else if (string.IsNullOrEmpty(txtLastName.Text))
        {
            DisplayMessages.AlertMessage(CommonMessages.RequireLastName);
            isValid = false;
        }
        else if (string.IsNullOrEmpty(txtAddress.Text))
        {
            DisplayMessages.AlertMessage(CommonMessages.RequireAddress);
            isValid = false;
        }
        else if (string.IsNullOrEmpty(txtMobileNo.Text))
        {
            DisplayMessages.AlertMessage(CommonMessages.RequirePhoneNo);
            isValid = false;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            DisplayMessages.AlertMessage(CommonMessages.RequireEmail);
            isValid = false;
        }
        else if (!CommonMessages.ValidateEmail(txtEmail.Text.Trim()))
        {
            DisplayMessages.AlertMessage(CommonMessages.InvalidEmail);
            isValid = false;
        }
        else
            isValid = true;
        return isValid;
    }

    private void BtnEdit_Tapped(object sender, EventArgs e)
    {
        try
        {
            if (sender is ImageButton imgEdit && imgEdit.BindingContext is Model.User mUser)
            {
                if (mUser.UserId > 0)
                {
                    grdAddUser.IsVisible = true;
                    grdUser.IsVisible = false;
                    txtEmail.IsEnabled = false;
                    txtFirstName.Text = mUser.FirstName;
                    txtLastName.Text = mUser.LastName;
                    txtAddress.Text = mUser.Address;
                    txtMobileNo.Text = mUser.MobileNo;
                    txtEmail.Text = mUser.Email;
                    UserId = mUser.UserId;
                }
            }
        }
        catch (Exception ex) 
        {
            var err = ex.Message;
        }
    }

    private async void BtnDelete_Tapped(object sender, EventArgs e)
    {
        try
        {
            if (sender is ImageButton imgEdit && imgEdit.BindingContext is Model.User mUser)
            {
                if (mUser.UserId > 0)
                {
                    var alertmsg = await App.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to delete this record?", "Ok", "Cancel");
                    if (alertmsg)
                    {
                        await App.Database.DeletePersonAsync(mUser.UserId);
                        BindUserData();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            var err = ex.Message;
        }
    }
    #endregion
}