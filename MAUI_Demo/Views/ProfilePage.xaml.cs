using Plugin.Media.Abstractions;
using Plugin.Media;

namespace MAUI_Demo.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }


    private async void ImageEdit_Clicked(object sender, EventArgs e)
    {
        //string action = await App.Current.MainPage.DisplayActionSheet("Action", "Cancel", "", "Pick Photo", "Take Photo");
        string action = await App.Current.MainPage.DisplayActionSheet("Action", "Cancel", "", "Gallery", "Camera");
        if (action == "Camera")
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    string localFilepath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    var sourcestream = await photo.OpenReadAsync();
                    FileStream fileStream = File.OpenWrite(localFilepath);
                    await sourcestream.CopyToAsync(fileStream);
                    PhotoImage.Source = ImageSource.FromFile(localFilepath);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
        }
        else if (action == "Gallery")
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
            });

            if (file == null)
                return;

            var image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                //imgByteArray = ConvertStreamToByteArray(stream);
                return stream;
            });
            PhotoImage.Source = image;

            //using (MemoryStream memory = new MemoryStream())
            //{
            //    Stream stream = file.GetStream();
            //    stream.CopyTo(memory);
            //    imageArray = memory.ToArray();
            //}


             //With MediaPicker functionality same as above
            //if (CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    FileResult photo = await MediaPicker.Default.PickPhotoAsync();
            //    if (photo != null)
            //    {
            //        string localFilepath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            //        var sourceStream = await photo.OpenReadAsync();
            //        using (FileStream fileStream = File.OpenWrite(localFilepath))
            //        {
            //            await sourceStream.CopyToAsync(fileStream);
            //        }
            //        PhotoImage.Source = ImageSource.FromFile(localFilepath);
            //    }
            //}
        }
    }
}