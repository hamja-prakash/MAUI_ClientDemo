using MAUI_Demo.Helpers;
using MAUI_Demo.Model;
using System.Collections.ObjectModel;

namespace MAUI_Demo.Views;

public partial class UsersPage : ContentPage
{

    #region [ Properties ]
    public ObservableCollection<User> mUsers;
    public int _userId = 1;
    public ImageButton ImageButton;
    #endregion

    public UsersPage()
    {
        InitializeComponent();
        mUsers = new ObservableCollection<Model.User>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindUserData();
    }

    #region [ Methods ]
    public void BindUserData()
    {
        try
        {
            if (Common.Users != null && Common.Users.Count > 0)
            {
                mUsers = Common.Users;
                lstUsers.ItemsSource = mUsers;
            }
            else
            {
                GetUsers();
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            Console.WriteLine(ex.Message);
        }
    }

    public void GetUsers()
    {
        try
        {
            mUsers.Add(new Model.User()
            {
                UserId = _userId++,
                UserImg = "img1.jpg",
                FirstName = "Margaret",
                LastName = "Wood",
                Address = "2941 Randal Drive",
                MobileNo = "201-866-1032",
                Email = "margaret@jou.com"
            });

            mUsers.Add(new Model.User()
            {
                UserId = _userId++,
                UserImg = "img2.jpg",
                FirstName = "Paul",
                LastName = "Walker",
                Address = "1384 Bria Road",
                MobileNo = "212-293-0877",
                Email = "paulr@army.com"
            });

            mUsers.Add(new Model.User()
            {
                UserId = _userId++,
                UserImg = "img3.jpg",
                FirstName = "Kenneth",
                LastName = "Hollander",
                Address = "585 Wern Street",
                MobileNo = "570-638-4207",
                Email = "kennethr@worm.us"
            });

            mUsers.Add(new Model.User()
            {
                UserId = _userId++,
                UserImg = "img4.jpg",
                FirstName = "Adele",
                LastName = "Dunham",
                Address = "2459 Froe Street",
                MobileNo = "817-906-5264",
                Email = "adele@day.com"
            });

            mUsers.Add(new Model.User()
            {
                UserId = _userId++,
                UserImg = "img5.jpg",
                FirstName = "Robert",
                LastName = "Powell",
                Address = "436 Carol Avenue",
                MobileNo = "808-821-4085",
                Email = "robert@jour.com"
            });

            if (mUsers != null && mUsers.Count > 0)
            {
                Common.Users = mUsers;
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
            var err = ex.Message;
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
            SearchUsersData();
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
            SearchUsersData();
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
            SearchUsersData();
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

    private void BtnEdit_Tapped(object sender, EventArgs e)
    {
        try
        {
            if (sender is ImageButton imgEdit && imgEdit.BindingContext is Model.User mUser)
            {
                if (mUser.UserId > 0)
                {
                    Navigation.PushAsync(new AddUserPage(mUser.UserId));
                    //grdAddUser.IsVisible = true;
                    //grdUser.IsVisible = false;
                    //txtEmail.IsEnabled = false;
                    //txtFirstName.Text = mUser.FirstName;
                    //txtLastName.Text = mUser.LastName;
                    //txtAddress.Text = mUser.Address;
                    //txtMobileNo.Text = mUser.MobileNo;
                    //txtEmail.Text = mUser.Email;
                    //_userId = mUser.UserId;
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
                    var alertmsg = await App.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to delete this record?", "OK", "Cancel");
                    if (alertmsg)
                    {
                        mUsers.Remove(mUser);
                        DisplayMessages.SuccessMessage(CommonMessages.DeleteUser);
                        lstUsers.ItemsSource = mUsers;
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