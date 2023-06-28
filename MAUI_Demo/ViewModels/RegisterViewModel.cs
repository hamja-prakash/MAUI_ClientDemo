using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Demo.Helpers;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Demo.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        public string show = "iconvsbpass.png";
        public string hide = "iconhidepass.png";
        //public Student mStudent;
        //public List<Student> mStudents;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string confirmPassword;

        [ObservableProperty]
        public string passwordicon;

        [ObservableProperty]
        public string confirmpasswordicon;

        [ObservableProperty]
        public bool isPasswordVisible;

        [ObservableProperty]
        public bool isCnfPasswordVisible;

        public RegisterViewModel()
        {
            try
            {
                Passwordicon = "iconhidepass.png";
                Confirmpasswordicon = "iconhidepass.png";
                IsPasswordVisible = true;
                IsCnfPasswordVisible = true;
                //mStudents = new List<Student>();
                //GetStudents();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void ImgPassword()
        {
            try
            {
                if (Passwordicon == hide)
                {
                    Passwordicon = show;
                    IsPasswordVisible = false;
                }
                else
                {
                    Passwordicon = hide;
                    IsPasswordVisible = true;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void SignUp()
        {
            try
            {
                //if (Validation())
                //{
                //    mStudent = new Student();
                //    mStudent.FirstName = FirstName;
                //    mStudent.LastName = LastName;
                //    mStudent.EmailAddress = Email;
                //    mStudent.Password = Password;
                //    mStudent.ConfirmPassword = ConfirmPassword;
                //    await App.Database.SaveStudentAsync(mStudent);
                //    DisplayMessages.SuccessMessage(CommonMessages.StudentSave);
                //    ClearControl();
                //}
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        public void ClearControl()
        {
            try
            {
                FirstName = string.Empty;
                LastName = string.Empty;
                Email = string.Empty;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void ImgCnfPassword()
        {
            try
            {
                if (Confirmpasswordicon == hide)
                {
                    Confirmpasswordicon = show;
                    IsCnfPasswordVisible = false;
                }
                else
                {
                    Confirmpasswordicon = hide;
                    IsCnfPasswordVisible = true;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        [RelayCommand]
        public void NavigateSignIn()
        {
            try
            {
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        //public bool Validation()
        //{
        //    bool isValid = false;

        //    if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName))
        //        DisplayMessages.AlertMessage(CommonMessages.RequireFirstName);

        //    else if (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName))
        //        DisplayMessages.AlertMessage(CommonMessages.RequireLastName);

        //    else if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
        //        DisplayMessages.AlertMessage(CommonMessages.RequireEmail);

        //    else if (!Common.ValidateEmail(Email.Trim()))
        //        DisplayMessages.AlertMessage(CommonMessages.InvalidEmail);

        //    else if (CheckEmailAvaibility())
        //        DisplayMessages.AlertMessage(CommonMessages.EmailExist);

        //    else if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
        //        DisplayMessages.AlertMessage(CommonMessages.RequirePassword);

        //    else if (!Common.ValidatePassword(Password))
        //        DisplayMessages.AlertMessage(CommonMessages.InvalidPassword);

        //    else if (string.IsNullOrEmpty(ConfirmPassword) || string.IsNullOrWhiteSpace(ConfirmPassword))
        //        DisplayMessages.AlertMessage(CommonMessages.RequireCnfPassword);

        //    else if (!Common.ValidatePassword(ConfirmPassword))
        //        DisplayMessages.AlertMessage(CommonMessages.InvalidPassword);

        //    else if (Password.Trim() != ConfirmPassword.Trim())
        //        DisplayMessages.AlertMessage(CommonMessages.MismatchPassword);

        //    else
        //        isValid = true;

        //    return isValid;
        //}

        //public async Task GetStudents()
        //{
        //    try
        //    {
        //        var studentList = await App.Database.GetStudentAsync();
        //        if (studentList != null && studentList.Count > 0)
        //        {
        //            mStudents = studentList.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var err = ex.Message;
        //    }
        //}

        //public bool CheckEmailAvaibility()
        //{
        //    bool isEmailExist = false;
        //    var EmailExist = mStudents.Where(x => x.EmailAddress.ToLower() == Email.ToLower()).FirstOrDefault();
        //    if (EmailExist != null)
        //        isEmailExist = true;
        //    else
        //        isEmailExist = false;
        //    return isEmailExist;
        //}

        //public static bool ValidateEmail(string value)
        //{
        //    Regex emailRegExp = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        //    bool isEmail = emailRegExp.IsMatch(value);
        //    return isEmail;
        //}

        //public static bool ValidatePassword(string value)
        //{
        //    Regex passwordRegExp = new Regex("((?=.*\\d)(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,16})");
        //    bool isPassword = passwordRegExp.IsMatch(value);
        //    return isPassword;
        //}
    }
}
