namespace Gift_Ideas.Pages
{
    using ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Xaml;
    using Windows.Devices.Geolocation;
    using System;
    public sealed partial class GiftDetailsPage : Page
    {
        public GiftDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var gift = e.Parameter as GiftViewModel;
            this.DataContext = gift;
            if (gift.Location[0] != 0 && gift.Location[1] != 0)
            {
                btnLocation.Visibility = Visibility.Visible;
            }
        }

        private async void OnLocationButtonClick(object sender, RoutedEventArgs e)
        {
            var gift = this.DataContext as GiftViewModel;
            var uri = string.Format("bingmaps:?cp={0:0.000000}~-{1:0.000000}&lvl=16", gift.Location[0], gift.Location[1]);
            var shopUri = new Uri(uri);

            // Launch the Windows Maps app
            var launcherOptions = new Windows.System.LauncherOptions();
            launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
            var success = await Windows.System.Launcher.LaunchUriAsync(shopUri, launcherOptions);
        }
    }
}
