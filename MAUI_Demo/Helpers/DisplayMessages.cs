using Acr.UserDialogs;
using Color = System.Drawing.Color;

namespace MAUI_Demo.Helpers
{
    public class DisplayMessages
    {
        public static void AlertMessage(string msg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(msg)
            {
                Position = ToastPosition.Top,
                BackgroundColor = Color.Black,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(2)
            });
        }

        public static void ErrorMessage(string msg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(msg)
            {
                Position = ToastPosition.Top,
                BackgroundColor = Color.Red,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(2)
            });
        }

        public static void SuccessMessage(string msg)
        {
            UserDialogs.Instance.Toast(new ToastConfig(msg)
            {
                Position = ToastPosition.Top,
                BackgroundColor = Color.Green,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(2)
            });
        }
    }
}
