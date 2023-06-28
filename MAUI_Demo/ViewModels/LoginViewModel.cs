using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Demo.Helpers;
using MAUI_Demo.Views;

namespace MAUI_Demo.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public string _emailAddress = "hamja.paldiwala@gmail.com";
        public string _password = "admin";

        public LoginViewModel()
        {
        }

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;


        [RelayCommand]
        public void NavigateRegisterPage()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void NavigateForgotPassword()
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        private void Login()
        {
            try
            {
                if (Validation())
                {
                   if(Email.ToLower() == _emailAddress && Password.ToLower() ==_password)
                    {
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        DisplayMessages.AlertMessage(CommonMessages.LoginFailed);
                    }
                }

                //App.Current.MainPage.Navigation.PushAsync(new AppShell());
                //Application.Current.MainPage = new AppShell();
                // App.Current.MainPage.Navigation.PushAsync(new LoginDataPage());
                //if (Validation())
                //{
                //    var mStudents = await App.Database.GetStudentAsync();
                //    if (mStudents != null && mStudents.Count > 0)
                //    {
                //        var UserExist = mStudents.Where(x => x.EmailAddress.ToLower().Equals(Email.ToLower()) &&
                //                                             x.Password.ToLower().Equals(Password.ToLower())).FirstOrDefault();
                //        if (UserExist != null)
                //        {
                //            App.Current.MainPage.Navigation.PushAsync(new LoginDataPage());
                //        }
                //        else
                //        {
                //            DisplayMessages.AlertMessage(CommonMessages.AccountNotExist);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        public bool Validation()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
                DisplayMessages.AlertMessage(CommonMessages.RequireEmail);
            else if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
                DisplayMessages.AlertMessage(CommonMessages.RequirePassword);
            else
                isValid = true;
            return isValid;
        }
    }
}
