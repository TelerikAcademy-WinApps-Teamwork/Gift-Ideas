namespace Gift_Ideas.Pages
{
    using Gift_Ideas.ViewModels;
    using Models;
    using Parse;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Windows.Devices.Geolocation;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class AddGiftPage : Page
    {
        public AddGiftPage()
        {
            this.InitializeComponent();
        }

        public StorageFile Photo { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.Photo = e.Parameter as StorageFile;
            var imageSource = new BitmapImage(new Uri(this.Photo.Path));
            this.GiftImage.Source = imageSource as ImageSource;
        }

        private async void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            var giftViewModel = this.DataContext as GiftViewModel;
            GiftModel giftModel = new GiftModel();

            if (giftViewModel.Title == null || giftViewModel.Title == string.Empty)
            {
                this.Toast.Message = "Please enter title!";
                return;
            }

            giftModel.Title = giftViewModel.Title;
            giftModel.TargetPerson = giftViewModel.TargetPerson;
            giftModel.Shop = giftViewModel.Shop;

            var imageAsByteArray = await GetBytesAsync(this.Photo);
            ParseFile file = new ParseFile("giftImage.jpg", imageAsByteArray);
            await file.SaveAsync();

            giftModel.Image = file;

            if (this.LocationCheckBox.IsChecked.Value == true)
            {
                var geolocator = new Geolocator();
                var geoPosition = await geolocator.GetGeopositionAsync();
                var point = new ParseGeoPoint(geoPosition.Coordinate.Latitude, geoPosition.Coordinate.Longitude);
                giftModel.Location = point;
            }

            try
            {
                giftModel.TargetPersonAge = int.Parse(giftViewModel.Age);
            }
            catch (Exception)
            {
                this.Toast.Message = "Age must be a number";
                return;
            }

            try
            {
                giftModel.Price = int.Parse(giftViewModel.Price);
            }
            catch (Exception)
            {
                this.Toast.Message = "Price must be a number";
                return;
            }

            try
            {
                await giftModel.SaveAsync();
            }
            catch (WebException)
            {
                this.Toast.Message = "Unable to upload gift!";
                return;
            }
            catch (Exception)
            {
                this.Toast.Message = "No internet connection!";
                return;
            }

            this.Frame.Navigate(typeof(ListGiftsPage), "Successfully uploaded a gift!");
        }

        private static async Task<byte[]> GetBytesAsync(StorageFile file)
        {
            byte[] fileBytes = null;
            if (file == null) return null;
            using (var stream = await file.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (var reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }
            return fileBytes;
        }

        private async void OnAddLocationChecked(object sender, RoutedEventArgs e)
        {
            await Geolocator.RequestAccessAsync();
        }
    }
}
