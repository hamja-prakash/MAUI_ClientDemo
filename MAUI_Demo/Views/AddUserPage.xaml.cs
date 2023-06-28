using MAUI_Demo.Helpers;
using MAUI_Demo.Model;

namespace MAUI_Demo.Views;

public partial class AddUserPage : ContentPage
{
    public int UserId = 0;
    public User mUser;
    public AddUserPage(int? userId = 0)
    {
        InitializeComponent();
        mUser = new User();
        if (userId > 0)
        {
            lblHeader.Text = "Edit Customer";
            this.UserId = userId.Value;
            mUser.UserId = userId.Value;
            BindUserData();
        }
        else
        {
            lblHeader.Text = "Add Customer";
        }
    }

    #region [Methods]
    public void BindUserData()
    {
        try
        {
            mUser = Common.Users.Where(x => x.UserId == this.UserId).FirstOrDefault();
            if (mUser != null)
            {
                txtEmail.IsEnabled = false;
                txtFirstName.Text = mUser.FirstName;
                txtLastName.Text = mUser.LastName;
                txtAddress.Text = mUser.Address;
                txtMobileNo.Text = mUser.MobileNo;
                txtEmail.Text = mUser.Email;
            }

        }
        catch (Exception ex)
        {
            var err = ex.Message;
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
        else if (!CommonMessages.ValidateEmail(txtEmail.Text.ToLower().Trim()))
        {
            DisplayMessages.AlertMessage(CommonMessages.InvalidEmail);
            isValid = false;
        }
        else
            isValid = true;
        return isValid;
    }

    public void NavigateBack()
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }
    #endregion


    #region [Events]
    private void btnback_clicked(object sender, EventArgs e)
    {
        try
        {
            NavigateBack();
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
                if (this.UserId > 0)
                {
                    muser.UserId = this.UserId;
                }
                else
                {
                    muser.UserId = Common.Users.Select(x => x.UserId).LastOrDefault() + 1;
                }
                muser.FirstName = txtFirstName.Text;
                muser.LastName = txtLastName.Text;
                muser.Address = txtAddress.Text;
                muser.MobileNo = txtMobileNo.Text;
                muser.Email = txtEmail.Text;
                muser.UserImg = "img1.jpg";
                if (UserId > 0)
                {
                    var existuser = Common.Users.Where(x => x.UserId == muser.UserId).FirstOrDefault();
                    if (existuser != null)
                    {
                        int ls = Common.Users.IndexOf(existuser);
                        Common.Users[ls] = muser;
                    }
                    //{
                    //    muser = existuser;

                    //    //Common.Users.Add(existuser);
                    //}
                    //await App.Database.UpdatePersonAsync(muser);
                }
                else
                    //await App.Database.SavePersonAsync(muser);
                    Common.Users.Add(muser);
                if (UserId > 0)
                    DisplayMessages.SuccessMessage(CommonMessages.UserUpdate);
                else
                    DisplayMessages.SuccessMessage(CommonMessages.UserSave);
                NavigateBack();
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
    }
    #endregion


}