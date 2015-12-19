namespace Gift_Ideas.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class ListGiftsPage : Page
    {
        private string message;

        public ListGiftsPage()
        {
            this.InitializeComponent();
            Loaded += (s, e) =>
            {
                if (this.message != null)
                {
                    this.Toast.Message = this.message;
                }
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                this.message = e.Parameter as string;
            }
        }

        private void OnGiftDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            this.Frame.Navigate(typeof(GiftDetailsPage), button.DataContext);
        }
    }
}
