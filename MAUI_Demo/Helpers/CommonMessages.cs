using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MAUI_Demo.Helpers
{
    public class CommonMessages
    {
        public static string RequireFirstName = "please enter first name";
        public static string RequireLastName = "please enter last name";
        public static string RequireAddress = "please enter address";
        public static string RequirePhoneNo = "please enter phone number";
        public static string RequireEmail = "please enter email address";
        public static string InvalidEmail = "please enter correct email address";
        public static string RequirePassword = "please enter password";
        public static string InvalidPassword = "Your password must be at least 8 characters including a lowercase letter, an uppercase letter, and a number";
        public static string RequireCnfPassword = "please enter confirm password";
        public static string MismatchPassword = "password and confirm password are mismatch";
        public static string AccountNotExist = "Account does not exist";
        public static string EmailExist = "Email already exist";
        public static string LoginFailed = "Invalid Email or Password";

        public static string StudentSave = "Student has been successfully saved";
        public static string UserSave = "Customer has been successfully saved";
        public static string UserUpdate = "Customer has been successfully updated";
        public static string DeleteRecord = "Record successfully deleted..";
        public static string DeleteUser = "Customer has been successfully deleted..";

        public static int ProductId = 0;

        public static bool ValidateEmail(string value)
        {
            Regex emailRegExp = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            bool isEmail = emailRegExp.IsMatch(value);
            return isEmail;
        }
    }
}
